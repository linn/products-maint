﻿namespace Linn.Products.Domain.Linnapps
{
    using System;
    using System.Collections.Generic;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.Exceptions;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.RemoteServices;

    public class SerialNumberFactory : ISerialNumberFactory
    {
        private readonly IRepository<SalesArticle, string> salesArticleRepository;

        private readonly ISernosPack sernosPack;

        public SerialNumberFactory(
            ISernosPack sernosPack,
            IRepository<SalesArticle, string> salesArticleRepository)
        {
            this.sernosPack = sernosPack;
            this.salesArticleRepository = salesArticleRepository;
        }

        public IEnumerable<SerialNumber> CreateSerialNumbers(
            string transCode,
            string articleNumber,
            int fromSerialNumber,
            int toSerialNumber,
            int? prevSerialNumber,
            int createdBy)
        {
            if ((transCode == "RN ISSUED" || transCode == "RN BUILT") && prevSerialNumber == null)
            {
                throw new InvalidSerialNumberTransactionException("RN ISSUED and RN BUILT transactions must have a previous serial number");
            }

            if ((transCode == "RN ISSUED" || transCode == "RN BUILT") && fromSerialNumber != toSerialNumber)
            {
                throw new InvalidSerialNumberTransactionException("RN ISSUED and RN BUILT transactions can only be for a single serial number");
            }

            var salesArticle = this.salesArticleRepository.FindById(articleNumber);
            if (salesArticle == null)
            {
                throw new ArticleNotFoundException($"Could not find Sales Article {articleNumber}");
            }

            string sernosGroup;

            try
            {
                sernosGroup = this.sernosPack.GetProductGroup(articleNumber);
            }
            catch (Exception e)
            {
                throw new InvalidSerialNumberTransactionException(e.Message);
            }

            if (string.IsNullOrEmpty(sernosGroup))
            {
                throw new InvalidArticleException($"Could not find Sernos Group for Sales Article {articleNumber}");
            }

            if (salesArticle.TypeOfSerialNumber == "N" || salesArticle.TypeOfSerialNumber == null)
            {
                throw new InvalidSerialNumberTransactionException("Sales Article must be serial numbered");
            }

            if (toSerialNumber < fromSerialNumber)
            {
                throw new InvalidDataException("To Serial Number should not be less than From Serial Number");
            }

            if ((salesArticle.TypeOfSerialNumber == "P1" || salesArticle.TypeOfSerialNumber == "P2")
                && (fromSerialNumber % 2 == 0 || toSerialNumber % 2 != 0))
            {
                throw new InvalidSerialNumberTransactionException("If creating pair of Serial Numbers sequence must start with the odd number and end with the even number");
            }

            var serialNumbers = new List<SerialNumber>();

            for (var currentSerialNumber = fromSerialNumber; currentSerialNumber <= toSerialNumber; currentSerialNumber++)
            {
                if (!this.sernosPack.CheckSernosTrans(transCode, articleNumber, currentSerialNumber))
                {
                    throw new InvalidSerialNumberTransactionException(this.sernosPack.GetSernosMessage());
                }

                serialNumbers.Add(new SerialNumber(sernosGroup, transCode, articleNumber, createdBy)
                                      {
                                          PrevSernosNumber = prevSerialNumber,
                                          SernosDate = DateTime.UtcNow,
                                          SernosNumber = currentSerialNumber
                                      });
            }

            return serialNumbers;
        }
    }
}