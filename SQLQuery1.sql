
select * from Cliente;

select * from Produto;

select Nome,Valor from Produto where Valor between 20 and 50; 

select Nome,Email from Cliente where Email like '%crefisa%'; 

select Nome,Email from Cliente where Email not like '%crefisa%';

select Nome,Sobrenome from Cliente order by Nome;

select c.ClienteId, c.Nome, c.Sobrenome, p.Nome, p.Valor from Cliente c inner join Produto p on c.ClienteId = p.ClienteId;

select c.ClienteId, c.Nome, c.Sobrenome, p.Nome from Cliente c join Produto p on c.DataCadastro >= 26/11/2021;

create table Cargo (Matricula number(2) primary key, Nome varchar(50), salario number(4)); 






