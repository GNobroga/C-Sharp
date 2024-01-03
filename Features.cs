

namespace features;

public static class Features 
{
    public class ClassWithInitialConstructor(string arg1, string arg2)
    {
        public string ArgUpper => arg1.ToUpper();
        public string ArgLower => arg2.ToLower();
    }

    public static string[] Names => 
    [
        "Gabriel",
        "Lívia",
        "Claudio",
        "José",
        "Pedrinho",
        "Other",
    ];

}