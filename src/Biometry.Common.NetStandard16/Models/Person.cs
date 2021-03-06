﻿using PipServices.Commons.Data;

namespace Biometry.Common.Models
{
    public sealed class Person: IStringIdentifiable
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
