namespace PhoneBook;

static internal class Validation
{
    static internal bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        string[] parts = email.Split('@');

        if (parts.Length != 2)
            return false;

        string localPart = parts[0];
        string domainPart = parts[1];

        if (string.IsNullOrWhiteSpace(localPart) || string.IsNullOrWhiteSpace(domainPart))
            return false;

        foreach (char c in localPart)
        {
            if (!char.IsLetterOrDigit(c) && c != '.' && c != '_' && c != '-')
                return false;
        }

        if (domainPart.Length < 2 || !domainPart.Contains(".") || domainPart.Split(".").Length != 2 || domainPart.EndsWith(".") || domainPart.StartsWith("."))
            return false;

        return true;
    }

    static internal bool IsValidPhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return false;

        if (phone.Length != 10)
            return false;

        foreach (char c in phone)
            if (!char.IsDigit(c))
                return false;

        return true;
    }
}
