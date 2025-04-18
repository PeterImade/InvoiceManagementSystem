using System.ComponentModel.Design;

namespace InvoiceAPI.Exceptions
{
    public sealed class InvoiceNotFoundException: NotFoundException
    {
        public InvoiceNotFoundException(int invoiceId): base($"The invoice with id: {invoiceId} doesn't exist in the database.")
        {
            
        }
    }
}
