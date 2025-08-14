using System.Text.Json;
using System.Text.Json.Serialization;

namespace Server.src
{
	public class JsonProtocol
	{
		public enum CommandEnum
		{
			NotInit,
			VerifiedLogin,
			UserLogin,
			UserJoin,
			UserLeave,
			UserMention,
			SendMessage,
			SendCommand,
			ServerOnline
		}
		public enum ErrorEnum
		{
			NoErrors,
			NameTooShort,
			NameTooLong,
			NameIsEmpty,
			NameNotAvailable,
			UserNotFound
		}

		public CommandEnum Command { get; }
		public ErrorEnum Error { get; }
		public string? Name { get; }
		public string? Message { get; }
		public int? Id { get; }
		public string[]? Strings { get; }
		public bool? Status { get; }
		public bool? Mentioned { get; }



		public JsonProtocol // полный конструктор
			(
			CommandEnum command,
			ErrorEnum error,
			string name,
			string message,
			int id,
			string[] strings,
			bool status,
			bool mentioned
			)
		{
			Command = command;
			Error = error;
			Name = name;
			Message = message;
			Id = id;
			Strings = strings;
			Status = status;
			Mentioned = mentioned;
		}

		/// <summary>
		/// Конструктор для авторизации пользователя
		/// </summary>
		/// <param name="command">Принимает вид команды</param>
		/// <param name="name">Имя пользователя для авторизации</param>
		public JsonProtocol
			(
			CommandEnum command,
			string name
			)
		{
			Command = command;
			Name = name;
			Error = 0;
			Message = null;
			Id = null;
			Strings = null;
			Status = null;
		}

		/// <summary>
		/// Конструктор для ошибки авторизации
		/// </summary>
		/// <param name="command">VerifiedLogin</param>
		/// <param name="status">Статус авторизации</param>
		/// <param name="error">Ошибка авторизации (опционально)</param>
		public JsonProtocol
			(
			CommandEnum command,
			bool status,
			ErrorEnum error = 0
			)
		{
			Command = command;
			Error = error;
			Status = status;
			Name = null;
			Message = null;
			Id = null;
			Strings = null;
		}



		private static readonly JsonSerializerOptions options = new()
		{
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
		};



		public static string Serialize(JsonProtocol jsonProtocol)
		{
			return JsonSerializer.Serialize(jsonProtocol, options);
		}

		public static JsonProtocol? Deserialize(string json)
		{
			return JsonSerializer.Deserialize<JsonProtocol>(json, options);
		}
	}
}