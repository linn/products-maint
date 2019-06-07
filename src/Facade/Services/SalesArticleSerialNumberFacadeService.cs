namespace Linn.Products.Facade.Services
{
    using System;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.Models;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.RemoteServices;

    public class SalesArticleSerialNumberFacadeService : ISalesArticleSerialNumberFacadeService
    {
        private readonly IRepository<SalesArticle, string> salesArticleRepository;

        private readonly ISernosPack sernosPack;

        public SalesArticleSerialNumberFacadeService(IRepository<SalesArticle, string> salesArticleRepository, ISernosPack sernosPack)
        {
            this.salesArticleRepository = salesArticleRepository;
            this.sernosPack = sernosPack;
        }

        public IResult<SalesArticleSerialNumberDetails> GetSerialNumberDetails(string articleNumber)
        {
            var salesArticleResponseModel = this.salesArticleRepository.FindById(articleNumber);
            if (salesArticleResponseModel == null)
            {
                return new NotFoundResult<SalesArticleSerialNumberDetails>($"Could not find Sales Article {articleNumber}");
            }

            string sernosGroup;

            try
            {
                sernosGroup = this.sernosPack.GetProductGroup(articleNumber);
            }
            catch (Exception e)
            {
                return new BadRequestResult<SalesArticleSerialNumberDetails>(e.Message);
            }

            var salesArticleSerialNumberDetails = new SalesArticleSerialNumberDetails
                                                      {
                                                          SerialNumberType = salesArticleResponseModel.TypeOfSerialNumber,
                                                          SernosGroup = sernosGroup
                                                      };

            return new SuccessResult<SalesArticleSerialNumberDetails>(salesArticleSerialNumberDetails);
        }
    }
}