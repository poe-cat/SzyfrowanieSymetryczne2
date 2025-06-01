# Symmetric Encryption App ver. 2

A Windows Forms application written in C# that allows users to encrypt and decrypt text using various symmetric encryption algorithms (AES, DES, TripleDES, RC2).

## Features

- Selectable encryption algorithm (via ComboBox)
- Key and IV (initialization vector) generation
- Plaintext input (ASCII)
- Display of encrypted output in:
  - ASCII
  - HEX
- Decryption back to plaintext
- Time measurement for encryption and decryption (in milliseconds)

## Supported Algorithms

- AES
- DES
- TripleDES
- RC2

## Interface Overview

The interface allows two-column layout:
- Left: labels and buttons (Encrypt / Decrypt)
- Right: input and output fields (Key, IV, PlainText, CipherText, Time results)

## How It Works

1. Select an encryption algorithm.
2. Click "Generate Key and IV" to generate cryptographic parameters.
3. Enter your message in the PlainText field.
4. Click "Encrypt" — encrypted output will appear.
5. Click "Decrypt" — the original message will be restored if parameters are correct.

## Requirements

- .NET 7 SDK (https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- Visual Studio 2022 or newer with .NET Desktop Development workload

## Benchmark (Task 2)

See `BenchmarkResults.md` for performance measurements:
- Time per encryption block
- Throughput in bytes per second (RAM and HDD)

Benchmark logic implemented in `Benchmark/EncryptionBenchmark.cs`

## Project Structure

```
SymmetricEncryptionApp/
├── README.md
├── .gitignore
├── BenchmarkResults.md
├── SymmetricEncryptionApp.csproj
├── Program.cs
├── Form1.cs
├── Form1.Designer.cs
└── Benchmark/
    └── EncryptionBenchmark.cs
```

## License

This project was created for educational purposes.
