using Factorial;
using Microsoft.Extensions.Localization;

namespace Factorialn
{
    public class ClientError
	{
		private Error _errorCode { get; }
		public string ErrorCode => _errorCode.ToString();
		public string? Field { get; }
		public LocalizedString LocalizedString { get; }

		public ClientError(Error code, LocalizedString localizedString, string? field)
		{
			_errorCode = code;
			LocalizedString = localizedString;
			Field = field;
		}
	}
}
