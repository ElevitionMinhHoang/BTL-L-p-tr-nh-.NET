using BCrypt.Net;

string password = "123456";
string hash = BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
Console.WriteLine($"Password: {password}");
Console.WriteLine($"Hash: {hash}");

bool verified = BCrypt.Net.BCrypt.Verify(password, hash);
Console.WriteLine($"Verified: {verified}");
