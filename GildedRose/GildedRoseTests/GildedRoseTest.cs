using System.Collections.Generic;
using System.Text;
using Argon;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

[UsesVerify]
public class GildedRoseTest
{


    public GildedRoseTest()
    {
        VerifierSettings.AddExtraSettings(serializerSettings =>
                serializerSettings.DefaultValueHandling = DefaultValueHandling.Include);
    }

    [Fact]
    public Task GoldenMasterProgram()
    {
        StringBuilder builder = new StringBuilder();
        TextWriter writer = new StringWriter(builder);

        Console.SetOut(writer);

        Program.Main(new string[] { });

        return Verify(builder.ToString());
    }
}
