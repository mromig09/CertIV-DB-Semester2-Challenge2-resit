/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
delete from sale;
delete from cd;
delete from clients;
delete from special_passion;

insert into special_passion (passionCode, passionDescription) values
('RR', 'Rock and Roll'),
('JA', 'Jazz'),
('RB', 'Rhythm and Blues');

insert into clients (clientNumber, name, address, postcode, passionCode) values
(123, 'Freddy Mercury', '1 Sesame Street', 3000, 'RR'),
(456, 'Brian May', '10 Downing Street', 4000, 'JA'),
(789, 'John Deacon', '221B Baker Street', 5000, 'RB'),
(234, 'Roger Taylor', 'LG1 College Cres, Parkville', 6000, 'RR'),
(567, 'Mike Grose', '1 Adelaide Avenue', 7000, 'RB');

insert into cd (cdID, cdName, artist) values
('PF003', 'The Wall', 'Pink Floyd'),
('IX002', 'Kick', 'INXS'),
('SP069', 'Never Mind the Bollocks', 'Sex Pistols'),
('PF002', 'The Dark Side of the Moon', 'Pink Floyd'),
('IX005', 'Moon', 'INXS'),
('SP070', 'Shabooh Shoobah', 'Sex Pistols'),
('PF004', 'The Endless River', 'Pink Floyd'),
('PF006', 'Wish You Were Here', 'Pink Floyd'),
('SP075', 'Agents of Anarchy', 'Sex Pistols'),
('PF007', 'The Division Bell', 'Pink Floyd');

insert into sale (dateOrdered, price, cdID, clientNumber, passionCode) values
('1-Dec-2019', 30.00, 'PF003', 123, 'RR'),
('1-Dec-2019', 29.95, 'IX002', 123, 'RR'),
('2-Dec-2019', 12.45, 'SP069', 123, 'RR'),
('5-Dec-2019', 30.00, 'IX002', 123, 'RR'),
('1-Dec-2019', 31.00, 'PF002', 456, 'JA'),
('3-Dec-2019', 28.95, 'IX005', 456, 'JA'),
('6-Dec-2019', 13.45, 'SP070', 456, 'JA'),
('2-Dec-2019', 29.00, 'PF004', 789, 'RB'),
('5-Dec-2019', 29.95, 'IX002', 789, 'RB'),
('1-Dec-2019', 45.00, 'PF006', 234, 'RR'),
('4-Dec-2019', 5.67, 'SP075', 234, 'RR'),
('3-Dec-2019', 9.95, 'PF007', 567, 'RB');
