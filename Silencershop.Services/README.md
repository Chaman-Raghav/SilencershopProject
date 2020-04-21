# SilencershopProject

Update appsetting.json file and update DataSource with your localDB dataSource.
`update-database` in pmc console

For adding migrations
1. `Add-Migration <Migration Name>`
2. `Update-Database`

Sometimes you add a migration and realize you need to make additional changes to your EF Core model before applying it. To remove the last migration, use this command.

```Remove-Migration```

After removing the migration, you can make the additional model changes and add it again.


If you already applied a migration (or several migrations) to the database but need to revert it, you can use the same command to apply migrations, but specify the name of the migration you want to roll back to.

`Update-Database <Last Good Migration>`

More Details https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=vs
