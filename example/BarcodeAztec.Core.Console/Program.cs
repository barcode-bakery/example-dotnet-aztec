using System.Threading.Tasks;

namespace BarcodeAztec.Core.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // See each barcode file to see how you can save to a file or a MemoryStream.
            await ExampleAztec.CreateAsync("barcode_aztec.png");
        }
    }
}
