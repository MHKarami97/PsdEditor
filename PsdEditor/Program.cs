using System.Text.Json;
using Aspose.PSD;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.ImageOptions;
using PsdEditor;

try
{
    Console.WriteLine("Start");

    new License().SetLicense("File/" + "License" + ".txt");

    await using var openStream = File.OpenRead("File/" + "data" + ".json");
    var data = await JsonSerializer.DeserializeAsync<Data>(openStream);

    if (data is null) throw new AggregateException("not valid data");

    var items = data.ToDictionary();

    using var psdImage = (PsdImage)Image.Load("File/" + "File" + ".psd");

    foreach (var layer in psdImage.Layers)
    {
        if (layer is TextLayer textLayer)
        {
            var isExist = items.TryGetValue(layer.DisplayName, out var item);

            if (isExist)
            {
                textLayer.UpdateText(item);
            }
        }
    }

    Directory.CreateDirectory("Result");
    psdImage.Save("Result/" + "FileResult" + ".png", new PngOptions());
    psdImage.Save("Result/" + "FileResult" + ".jpg", new JpegOptions());

    Console.WriteLine("Finish");
}
catch (Exception e)
{
    Console.WriteLine(e);
}