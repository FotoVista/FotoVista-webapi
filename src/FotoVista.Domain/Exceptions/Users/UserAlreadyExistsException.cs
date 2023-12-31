﻿namespace FotoVista.Domain.Exceptions.Users;

public class UserAlreadyExistsException : AlreadyExistsExcaption
{
	public UserAlreadyExistsException()
	{
		TitleMessage = "User already exists";
	}

	public UserAlreadyExistsException(string phone)
	{
		TitleMessage = "This email is already registered";
	}
}
