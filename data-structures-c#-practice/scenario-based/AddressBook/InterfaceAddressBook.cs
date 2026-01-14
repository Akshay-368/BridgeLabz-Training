// File: IAddrBk.cs

// This interface defines the basic functions that any address book system should have. It uses OOP concepts like interface to declare methods that classes will implement. This helps in polymorphism where different classes can provide their own way of doing things while following the same contract. We are keeping it simple following KISS principle, and not adding too many methods to follow YAGNI - only what is needed now. For SOLID, this supports Interface Segregation by keeping interface focused on address book operations.

public interface IAddrBk
{
    void AddCntct(string bkNm, Cntct cnt); // Method to add a contact to a specific book
    void EdtCntct(string bkNm, string frstNm, string lstNm); // Edit contact by name
    void DelCntct(string bkNm, string frstNm, string lstNm); // Delete contact by name
    void AddMltiCntcts(string bkNm); // Add multiple contacts
    void AddNwBk(string bkNm); // Add new address book
    bool ChkDupl(string bkNm, string frstNm, string lstNm); // Check for duplicate
    void SrchPrsnInCtyOrSt(string ctyOrSt); // Search persons in city or state
    void VwPrsnsByCtyOrSt(); // View persons by city or state
    int CntByCtyOrSt(string ctyOrSt); // Count by city or state
    void SrtByNm(string bkNm); // Sort entries by name
    // Note : We will leave file, db, cloud for child classes to override if needed.
}
