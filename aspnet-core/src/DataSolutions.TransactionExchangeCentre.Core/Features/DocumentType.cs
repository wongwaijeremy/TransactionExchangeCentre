namespace DataSolutions.TransactionExchangeCentre.Features
{
    public enum DocumentType
    {
        NotDecided = 0,
        PurchaseOrder = 10,
        PreAsn = 20,
        CASN = 30,
        ASN = 40,
        Invoice = 50,
        Acknowledgement = 60,
        EDI810 = 810,
        EDI850 = 850,
        EDI855 = 855,
        EDI856 = 856,
        EDI860 = 860,
        DOC997 = 997
    }
}