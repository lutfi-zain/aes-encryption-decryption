# README.md

# AES Encryption and Decryption

This project provides a class `aesEncryptionDecryption` that implements encryption and decryption functionalities using AES (Advanced Encryption Standard). It includes methods for encrypting and decrypting data with a salted approach.

## Installation

To use the `aesEncryptionDecryption` class in your .NET project, you can install the package from GitHub Packages. Make sure you have the necessary permissions and your GitHub credentials configured.

1. Add the GitHub Packages source to your NuGet configuration:

   ```
   dotnet nuget add source --name github --username <GITHUB_USERNAME> --password <GITHUB_TOKEN> --store-password-in-clear-text https://nuget.pkg.github.com/<GITHUB_USERNAME>/index.json
   ```

2. Install the package:

   ```
   dotnet add package <PackageId>
   ```

Replace `<PackageId>` with the actual package ID defined in the `aesEncryptionDecryption.csproj` file.

## Usage

To use the `aesEncryptionDecryption` class, include the namespace in your project:

```csharp
using aesEncryptionDecryptionNamespace; // Replace with the actual namespace
```

You can then create an instance of the class and use its methods:

```csharp
var aes = new aesEncryptionDecryption();
string encryptedData = aes.EncryptCryptoJSSalted("your data here", "your password here");
string decryptedData = aes.DecryptCryptoJSSalted(encryptedData, "your password here");
```

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue for any enhancements or bug fixes.

## License

This project is licensed under the MIT License. See the LICENSE file for more details.