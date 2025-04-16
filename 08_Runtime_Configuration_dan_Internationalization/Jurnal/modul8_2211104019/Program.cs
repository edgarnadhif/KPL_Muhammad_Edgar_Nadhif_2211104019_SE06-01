using System;

class Program
{
    static void Main()
    {
        BankTransferConfig config = BankTransferConfig.LoadConfig();
        string lang = config.Lang;

        // Step 1: Prompt nominal transfer
        Console.WriteLine(lang == "en"
            ? "Please insert the amount of money to transfer:"
            : "Masukkan jumlah uang yang akan di-transfer:");

        int amount = int.Parse(Console.ReadLine());

        // Step 2: Calculate transfer fee
        int fee = amount <= config.Transfer.Threshold ? config.Transfer.LowFee : config.Transfer.HighFee;
        int total = amount + fee;

        // Step 3: Display fee and total
        if (lang == "en")
        {
            Console.WriteLine($"Transfer fee = {fee}");
            Console.WriteLine($"Total amount = {total}");
        }
        else
        {
            Console.WriteLine($"Biaya transfer = {fee}");
            Console.WriteLine($"Total biaya = {total}");
        }

        // Step 4: Transfer method
        Console.WriteLine(lang == "en" ? "Select transfer method:" : "Pilih metode transfer:");
        for (int i = 0; i < config.Methods.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {config.Methods[i]}");
        }

        int methodChoice = int.Parse(Console.ReadLine());

        // Step 5: Confirmation
        string confirmText = lang == "en" ? config.Confirmation.En : config.Confirmation.Id;
        Console.WriteLine(lang == "en"
            ? $"Please type \"{confirmText}\" to confirm the transaction:"
            : $"Ketik \"{confirmText}\" untuk mengkonfirmasi transaksi:");

        string userInput = Console.ReadLine();

        // Step 6: Final confirmation
        if (userInput == confirmText)
        {
            Console.WriteLine(lang == "en"
                ? "The transfer is completed"
                : "Proses transfer berhasil");
        }
        else
        {
            Console.WriteLine(lang == "en"
                ? "Transfer is cancelled"
                : "Transfer dibatalkan");
        }
    }
}
