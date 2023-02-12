﻿using Microsoft.EntityFrameworkCore;

namespace Geekshopping.ProductAPI.Model.Context {
    public class MySQLContext : DbContext {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }
    }
}
