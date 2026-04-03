// File: Cntct.cs

// Simple class for contact, with fields. Encapsulation with public properties, but since style, public fields. Wait, for encapsulation, properties.

public class Cntct
{
    public string fn; // first name
    public string ln; // last name
    public string addr;
    public string cty;
    public string st;
    public string zp;
    public string ph;
    public string em;

    public override string ToString()
    {
        return $"{fn} {ln} {addr} {cty} {st} {zp} {ph} {em}";
    }
}
