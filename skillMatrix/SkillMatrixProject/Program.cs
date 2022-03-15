using JsonPatchSample;
using Microsoft.EntityFrameworkCore;


using skillMatrix.WebAPI.Data.DataContext;
using SkillMatrixProject.Models;
using SkillMatrixProject.Repositories;
using SkillMatrixProject.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DBConnection");
var postgreConnectionString = builder.Configuration.GetConnectionString("PostgreDbConnection");
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PostgreDbContext>(options =>
        options.UseNpgsql(postgreConnectionString));
builder.Services.AddDbContext<SkillMatrixDbContext>(options =>
        options.UseSqlServer(connectionString));
builder.Services.AddScoped<IRepository<Employee>, EmployeeRepo>();
builder.Services.AddScoped<IRepository<ContractStatus>, ContractStatusRepo>();
builder.Services.AddScoped<IRepository<Department>, DepartmentRepo>();
builder.Services.AddScoped<IRepository<EmploymentStatus>, EmploymentStatusRepo>();
builder.Services.AddScoped<IRepository<Jobtitle>, JobtitleRepo>();
builder.Services.AddScoped<IRepository<Skill>, SkillRepo>();
builder.Services.AddScoped<IRepository<SkillCategory>, SkillCategoriesRepo>();
builder.Services.AddScoped<IRepository<SkillLevel>, SkillLevelsRepo>();
builder.Services.AddTransient<ISkillService, SkillService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllers(options =>
{
    options.InputFormatters.Insert(0, MyJPIF.GetJsonPatchInputFormatter());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
