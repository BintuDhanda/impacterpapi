using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using ERP.Bussiness;
using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var env = builder.Configuration["EnvironmentVariable"];
var connectionString = builder.Configuration.GetConnectionString("ERPContext" + env);
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(connectionString));

// Register the PushNotificationService.
builder.Services.AddScoped<PushNotificationService>();
//builder.Services.AddHostedService<PushNotificationBackgroundService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
    };
});

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<IUserRole, UserRoleRepository>();
builder.Services.AddScoped<ICourse, CourseRepositry>();
builder.Services.AddScoped<IStudentBatch, StudentBatchRepository>();
builder.Services.AddScoped<ICourseCategory, CourseCategoryRepository>();
builder.Services.AddScoped<IRole, RoleRepository>();
builder.Services.AddScoped<ICountry, CountryRepository>();
builder.Services.AddScoped<IState, StateRepository>();
builder.Services.AddScoped<ICity, CityRepository>();
builder.Services.AddScoped<IPincode, PincodeRepository>();
builder.Services.AddScoped<IAccount, AccountRepository>();
builder.Services.AddScoped<IAccountCategory, AccountCategoryRepository>();
builder.Services.AddScoped<IDayBook, DayBookRepository>();
builder.Services.AddScoped<IBoard, BoardRepository>();
builder.Services.AddScoped<IUniversity, UniversityRepository>();
builder.Services.AddScoped<IStudentDetails, StudentDetailsRepository>();
builder.Services.AddScoped<IQualification, QualificationRepository>();
builder.Services.AddScoped<IStudentQualification, StudentQualificationRepository>();
builder.Services.AddScoped<IStudentContact, StudentContactRepository>();
builder.Services.AddScoped<IStudentAddress, StudentAddressRepository>();
builder.Services.AddScoped<IAddressType, AddressTypeRepository>();
builder.Services.AddScoped<IBatch, BatchRepository>();
builder.Services.AddScoped<IStudentTokenFees, StudentTokenFeesRepository>();
builder.Services.AddScoped<IStudentToken, StudentTokenRepository>();
builder.Services.AddScoped<IRegistration, RegistrationRepository>();
builder.Services.AddScoped<IAttendance, AttendanceRepository>();
builder.Services.AddScoped<IStudent, StudentRepository>();
builder.Services.AddScoped<IStudentBatchFees, StudentBatchFeesRepository>();
builder.Services.AddScoped<IFeeType, FeeTypeRepository>();
builder.Services.AddScoped<INews, NewsRepository>();
builder.Services.AddScoped<INewsLike, NewsLikeRepository>();
builder.Services.AddScoped<INewsComment, NewsCommentRepository>();
builder.Services.AddScoped<IIdentityType, IdentityTypeRepository>();
builder.Services.AddScoped<IStudentIdentities, StudentIdentitiesRepository>();
builder.Services.AddScoped<ISlider, SliderRepository>();
builder.Services.AddScoped<IHostel, HostelRepository>();
builder.Services.AddScoped<IHostelRoom, HostelRoomRepository>();
builder.Services.AddScoped<IHostelRoomBad, HostelRoomBadRepository>();
builder.Services.AddScoped<IHostelRoomBadStudent, HostelRoomBadStudentRepository>();
builder.Services.AddScoped<IHostelRoomBadStudentRent, HostelRoomBadStudentRentRepository>();
builder.Services.AddScoped<IStudentHostelRoomBadRent, StudentHostelRoomBadRentRepository>();
builder.Services.AddScoped<IAcademy, AcademyRepository>();
builder.Services.AddScoped<ICommon, CommonRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}
app.UseStaticFiles();

app.UseCors("CorsPolicy");
//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
