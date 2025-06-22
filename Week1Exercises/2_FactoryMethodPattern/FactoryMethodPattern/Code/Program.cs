class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Document Management System");
        Console.WriteLine("--------------------------");

        DocumentFactory wordFactory = new WordDocumentFactory();
        DocumentFactory pdfFactory = new PdfDocumentFactory();
        DocumentFactory excelFactory = new ExcelDocumentFactory();

        var wordDoc = wordFactory.CreateDocument();
        var pdfDoc = pdfFactory.CreateDocument();
        var excelDoc = excelFactory.CreateDocument();

        Console.WriteLine(wordDoc.Print());
        Console.WriteLine(pdfDoc.Print());
        Console.WriteLine(excelDoc.Print());
    }
}
