var rootCommand = new RootCommand("Token tool to generate or validate tokens");

var sellerIdArgument = new Argument<Guid>(name: "sellerId", description: "Seller ID");
var sellerEmailArgument = new Argument<string>(name: "email", description: "Seller email");
var secretKeyToGenerateArgument = new Argument<string>(name: "secretKey", description: "Secret key to sign the token");

var generateCommand = new Command("generate", "Generate a token")
{
    sellerIdArgument,
    sellerEmailArgument,
    secretKeyToGenerateArgument
};

generateCommand.SetHandler(handle: (sellerId, email, secretKey) =>
    {
        var webComponentJwtPayload = new WebComponentJwtPayload(
            sellerId: sellerId,
            email: email
        );

        var token = webComponentJwtPayload.GenerateSignedToken(secretKey: secretKey);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nGenerated Token:\n" + token);
        Console.ResetColor();
    },
    symbol1: sellerIdArgument,
    symbol2: sellerEmailArgument,
    symbol3: secretKeyToGenerateArgument
);

var tokenArgument = new Argument<string>(name: "token", description: "Token to validate");
var secretKeyToValidateArgument = new Argument<string>(name: "secretKey", description: "Secret key used to sign the token");

var validateCommand = new Command("validate", "Validate a token")
{
    tokenArgument,
    secretKeyToValidateArgument
};

validateCommand.SetHandler(handle: (token, secretKey) =>
    {
        var validateResult = JwtExtensions.Validate(token: token, secretKey: secretKey);

        if (validateResult.IsSuccess)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Token is valid.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Token is invalid.");
        }

        Console.ResetColor();
    },
    symbol1: tokenArgument,
    symbol2: secretKeyToValidateArgument
);

rootCommand.AddCommand(generateCommand);
rootCommand.AddCommand(validateCommand);

if (args.Length == 0)
{
    ShowMenu();
}
else
{
    return await rootCommand.InvokeAsync(args);
}

return 0;

void ShowMenu()
{
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1 - Generate token");
    Console.WriteLine("2 - Validate token");
    Console.Write("Enter your choice: ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            GenerateInteractive();
            break;
        case "2":
            ValidateInteractive();
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid option");
            Console.ResetColor();
            break;
    }
}

void GenerateInteractive()
{
    Console.Write("Seller ID (GUID): ");
    var sellerIdInput = Console.ReadLine();
    Console.Write("Email: ");
    var email = Console.ReadLine();
    Console.Write("Secret key: ");
    var secretKey = Console.ReadLine();

    if (!Guid.TryParse(sellerIdInput, out var sellerId))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid GUID");
        Console.ResetColor();
        return;
    }

    var token = new WebComponentJwtPayload(sellerId, email!).GenerateSignedToken(secretKey!);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\nGenerated Token:\n" + token);
    Console.ResetColor();
}

void ValidateInteractive()
{
    Console.Write("Token: ");
    var token = Console.ReadLine();
    Console.Write("Secret key: ");
    var secretKey = Console.ReadLine();

    var validateResult = JwtExtensions.Validate(token!, secretKey!);
    
    if (validateResult.IsSuccess)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Token is valid");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Token is invalid");
    }

    Console.ResetColor();
}