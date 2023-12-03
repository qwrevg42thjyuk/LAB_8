using System;
using System.Collections.Generic;

// Prototype
public interface IDataFormatPrototype
{
    IDataFormatPrototype Clone();
    void DisplayData();
}

// ConcretePrototype1
public class CSVDataFormat : IDataFormatPrototype
{
    private List<string[]> data;

    public CSVDataFormat(List<string[]> data)
    {
        this.data = data;
    }

    public IDataFormatPrototype Clone()
    {
        return new CSVDataFormat(data);
    }

    public void DisplayData()
    {
        Console.WriteLine("Displaying CSV Data");
        foreach (var row in data)
        {
            Console.WriteLine(string.Join(", ", row));
        }
    }
}

// ConcretePrototype2
public class XMLDataFormat : IDataFormatPrototype
{
    private string data;

    public XMLDataFormat(string data)
    {
        this.data = data;
    }

    public IDataFormatPrototype Clone()
    {
        return new XMLDataFormat(data);
    }

    public void DisplayData()
    {
        Console.WriteLine("Displaying XML Data");
        Console.WriteLine(data);
    }
}

// Adapter
public interface IDataFormatAdapter
{
    IDataFormatPrototype ConvertData();
}

// ConcreteAdapter1
public class CSVtoXMLAdapter : IDataFormatAdapter
{
    private IDataFormatPrototype csvData;

    public CSVtoXMLAdapter(IDataFormatPrototype csvData)
    {
        this.csvData = csvData;
    }

    public IDataFormatPrototype ConvertData()
    {
        // Logic to convert CSV to XML
        Console.WriteLine("Converting CSV to XML");
        // Just returning a clone for simplicity
        return csvData.Clone();
    }
}

// Client
public class DataConverter
{
    public void ConvertData(IDataFormatAdapter adapter)
    {
        IDataFormat
