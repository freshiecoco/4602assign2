var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<FoundationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

builder.Services.AddScoped<DonorService>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<TransactionService>();
builder.Services.AddScoped<DonationService>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(
options => {
            options.Stores.MaxLengthForKeys = 128;
})
.AddEntityFrameworkStores<FoundationDbContext>()
.AddRoles<IdentityRole>()
.AddDefaultUI() .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

using (var scope = app.Services.CreateScope()) {
          var services = scope.ServiceProvider;
          var context = services.GetRequiredService<FoundationDbContext>();
          context.Database.Migrate();
          var userMgr = services.GetRequiredService<UserManager<IdentityUser>>();
          var roleMgr = services.GetRequiredService<RoleManager<IdentityRole>>();   
          IdentitySeedData.Initialize(context, userMgr, roleMgr).Wait();
}

app.Run();
