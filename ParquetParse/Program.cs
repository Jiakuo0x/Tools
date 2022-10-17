while (true)
{
    Console.WriteLine("Please wirte the parquet file name: ");
    var parquetFileName = Console.ReadLine();
    if (!File.Exists(parquetFileName))
    {
        Console.WriteLine($"Not found the file: {parquetFileName}.");
        return;
    }
    var reader = await ParquetReader.ReadTableFromFileAsync(parquetFileName);
    foreach (var item in reader)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine("--------------------------------------------------------------");
}