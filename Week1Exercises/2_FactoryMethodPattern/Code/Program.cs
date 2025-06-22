using System;

// The Product interface
interface IDocument
{
    string Print();
}

// Concrete Products
class WordDocument : IDocument
{
    public string Print() => "Word Document Printed";
}

class PdfDocument : IDocument
{
    public string Print() => "PDF Document Printed";
}

class ExcelDocument : IDocument
{
    public string Print() => "Excel Document Printed";
}

// The Creator abstract class
abstract class DocumentFactory
{
    public abstract IDocument CreateDocument();
}

// Concrete Creators
class WordDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument() => new WordDocument();
}

class PdfDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument() => new PdfDocument();
}

class ExcelDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument() => new ExcelDocument();
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Document Management System");
        Console.WriteLine("--------------------------");

        DocumentFactory wordFactory = new WordDocumentFactory();
        DocumentFactory pdfFactory = new PdfDocumentFactory();
        DocumentFactory excelFactory = new ExcelDocumentFactory();

        IDocument wordDoc = wordFactory.CreateDocument();
        IDocument pdfDoc = pdfFactory.CreateDocument();
        IDocument excelDoc = excelFactory.CreateDocument();

        Console.WriteLine(wordDoc.Print());
        Console.WriteLine(pdfDoc.Print());
        Console.WriteLine(excelDoc.Print());
    }
}
