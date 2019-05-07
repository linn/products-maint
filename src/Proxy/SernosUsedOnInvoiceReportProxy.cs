﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Linn.Products.Proxy
{
    using System.Data;

    using Linn.Common.Configuration;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps.RemoteServices;

    using Oracle.ManagedDataAccess.Client;

    public class SernosUsedOnInvoiceReportProxy : ISernosUsedOnInvoiceDatabaseService
    {
        private readonly OracleConnection connection;

        public SernosUsedOnInvoiceReportProxy()
        {
            this.connection = new OracleConnection(ConnectionStrings.ManagedConnectionString());
        }

        public DataTable GetReport(int? invoiceNumber, int? consignmentNumber)
        {
            var queryClause = this.BuildQueryClause(invoiceNumber, consignmentNumber); 
            var sql = $@"SELECT SALES_OUTLETS.NAME,
                         INVOICES.CONSIGNMENT_ID, INVOICES.DOCUMENT_NUMBER DOC_NUMBER, INVOICED_ITEMS.INVOICE_LINE,
                         INVOICED_ITEMS.SALES_ORDER_NUMBER, INVOICED_ITEMS.ORDER_LINE, WANDLOG.ARTICLE_NUMBER,
                         INVOICED_ITEMS.QTY, WANDLOG.WARRANTY_CARD_NUMBER, INVOICE_DETAILS.DESCRIPTION,
                         WANDLOG.SERIAL_NUMBER_1, WANDLOG.SERIAL_NUMBER_2
                         FROM WANDLOG, INVOICES, INVOICED_ITEMS,
                         INVOICE_DETAILS, SALES_OUTLETS
                         WHERE (WANDLOG.SERIAL_NUMBER_1 IS NOT NULL
                         OR WANDLOG.SERIAL_NUMBER_2 IS NOT NULL
                         OR WANDLOG.WARRANTY_CARD_NUMBER IS NOT NULL)
                         AND INVOICES.DOCUMENT_TYPE='I'
                         {queryClause}
                         AND WANDLOG.TRANS_TYPE = 'W'
                         AND (INVOICED_ITEMS.INVOICE_LINE=INVOICE_DETAILS.LINE_NO)
                         AND (INVOICED_ITEMS.INVOICE_NUMBER=INVOICE_DETAILS.DOCUMENT_NUMBER)
                         AND (INVOICE_DETAILS.OUTLET_NUMBER=SALES_OUTLETS.OUTLET_NUMBER)
                         AND (INVOICE_DETAILS.ACCOUNT_ID=SALES_OUTLETS.ACCOUNT_ID)
                         AND (WANDLOG.ORDER_LINE=INVOICED_ITEMS.ORDER_LINE)
                         AND (WANDLOG.ORDER_NUMBER=INVOICED_ITEMS.SALES_ORDER_NUMBER)
                         AND (INVOICE_DETAILS.DOCUMENT_TYPE=INVOICES.DOCUMENT_TYPE)
                         AND (INVOICE_DETAILS.DOCUMENT_NUMBER=INVOICES.DOCUMENT_NUMBER)
                         AND (INVOICES.CONSIGNMENT_ID=WANDLOG.CONSIGNMENT_ID)
                         and WANDLOG.UNWANDED_BY_WANDLOG_ID is NULL
                         ORDER BY SALES_OUTLETS.NAME ASC";

            var cmd = new OracleCommand(sql, this.connection) { CommandType = CommandType.Text };
            var dataAdapter = new OracleDataAdapter(cmd);
            var dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            return dataSet.Tables[0];
        }

        private string BuildQueryClause(int? invoiceNumber, int? consignmentNumber)
        {
            if (invoiceNumber != null && consignmentNumber == null)
            {
                return $@"AND INVOICES.DOCUMENT_NUMBER = {invoiceNumber}";
            }

            if (invoiceNumber == null && consignmentNumber != null)
            {
                return $@"AND WANDLOG.CONSIGNMENT_ID = {consignmentNumber}";
            }

            if (invoiceNumber != null && consignmentNumber != null)
            {
                return
                    $@"AND INVOICES.DOCUMENT_NUMBER = {invoiceNumber} AND WANDLOG.CONSIGNMENT_ID = {consignmentNumber}";
            }
            throw new ArgumentException("Both arguments cannot be null");
        }
    }
}
