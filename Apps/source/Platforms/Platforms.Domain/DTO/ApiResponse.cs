using System;
namespace Platforms.Domain.DTO
{
	public class ApiResponse
	{
        public bool HasException { get; set; } = false;

        public string Message { get; set; }

        public object Entity { get; set; }

        public object EntityList { get; set; }

    }

}

