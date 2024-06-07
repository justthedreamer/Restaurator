using Core;
using Core.Exceptions;

namespace Application.Exceptions;

public class AccountAlreadyExist(string email) : ConflictException($"Account with provided email {email} already exist.");
