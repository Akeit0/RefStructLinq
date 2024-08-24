using RefStructLinq;
using System.Text;


var s = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."u8;
foreach (var text in s.SplitEnumerable(" "u8)
             .Where(x => char.IsUpper((char)x[0]))
             .Select(x => Encoding.UTF8.GetString(x)))
{
    Console.WriteLine(text);
}

var s2 = s.ToRefStructEnumerable()
    .Where(x => char.IsUpper((char)x));
foreach (var c in s2)
    
{ Console.WriteLine((char)c);
    foreach (var c2 in s2)
    {
        Console.WriteLine((char)c2);
    }
}

// Output:
/*
Lorem         | L
Ut            | U
Duis          | D
Excepteur     | E
*/