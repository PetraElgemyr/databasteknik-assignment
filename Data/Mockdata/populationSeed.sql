INSERT INTO Roles (RoleName) VALUES ('Projektledare');
INSERT INTO Roles (RoleName) VALUES ('Utbildare');
INSERT INTO Roles (RoleName) VALUES ('Utvecklare');
INSERT INTO Roles (RoleName) VALUES ('Designer');

INSERT INTO StatusTypes (StatusTypeName) VALUES ('Ej påbörjad');
INSERT INTO StatusTypes (StatusTypeName) VALUES ('Pågående');
INSERT INTO StatusTypes (StatusTypeName) VALUES ('Avslutad');
INSERT INTO StatusTypes (StatusTypeName) VALUES ('Avbruten');

INSERT INTO Users VALUES ('Arvid', 'Vigren', 'vigren@icloud.com', '0712345678', 1);
INSERT INTO Users VALUES ('Petra', 'Elgemyr', 'pet@domain.com', null, 3);
INSERT INTO Users VALUES ('Thor', 'Elgemyr', 'thor@gmail.com', '111-22233344', 4);
INSERT INTO Users VALUES ('Hans', 'Mattin-Lassei', 'hans@domain.com', '444 555 66 67', 2);
INSERT INTO Users VALUES ('Gunilla', 'Simonsson', 'gunilla@domain.com', null, 1);
INSERT INTO Users VALUES ('Nils', 'Herrmansson', 'nisse@gmail.com', null, 1);
INSERT INTO Users VALUES ('Ebba Matilde', 'Regn', 'ebba@hotmail.com', null, 4);


INSERT INTO Services VALUES ('Konsulttid',1500)
INSERT INTO Services VALUES ('Konsulttid',1290)
INSERT INTO Services VALUES ('Anställd',800)
INSERT INTO Services VALUES ('Konsulttid',1199)


INSERT INTO CustomerTypes VALUES ('Företag')
INSERT INTO CustomerTypes VALUES ('Privatperson')

INSERT INTO Customers VALUES ('Nackademin AB', 1)
INSERT INTO Customers VALUES ('EPN Sverige AB', 1)
INSERT INTO Customers VALUES ('Vigren', 2)
INSERT INTO Customers VALUES ('Nisses Herrmode', 1)

INSERT INTO CustomerContacts VALUES ('Johan', 'Vigren', 'johan@live.se','071-234 56 43', 3)
INSERT INTO CustomerContacts VALUES ('Arvid', 'Vigren', 'vigren@icloud.com','0712345678', 3)
INSERT INTO CustomerContacts VALUES ('Astrid', 'Nacka', 'astidnack@gmail.com', null , 1)
INSERT INTO CustomerContacts VALUES ('Hans', 'Mattin-Lassei', 'hans@domain.com', null , 2)
INSERT INTO CustomerContacts VALUES ('Nils', 'Herrmansson', 'nisse@gmail.com', null , 4)
INSERT INTO CustomerContacts VALUES ('Ebba Matilde', 'Regn', 'ebba@domain.com', null , 4)
INSERT INTO CustomerContacts VALUES ('Signe', 'Nilsson', 'snils@domain.com', null , 4)

INSERT INTO PostalCodes VALUES ('211 14', 'Malmö')
INSERT INTO PostalCodes VALUES ('411 49', 'Göteborg')
INSERT INTO PostalCodes VALUES ('211 57', 'Malmö')
INSERT INTO PostalCodes VALUES ('12149', 'Stockholm')
INSERT INTO PostalCodes VALUES ('12841', 'Stockholm')
INSERT INTO PostalCodes VALUES ('411 18', 'Göteborg')
INSERT INTO PostalCodes VALUES ('12056', 'Stockholm')
INSERT INTO PostalCodes VALUES ('405 30', 'Göteborg')

INSERT INTO CustomerAddresses VALUES ('Malmövägen', '42', '12149', 2)
INSERT INTO CustomerAddresses VALUES ('Malmövägen', '42', '12149', 1)
INSERT INTO CustomerAddresses VALUES ('Göteborgsvägen', '12a', '411 49', 3)
INSERT INTO CustomerAddresses VALUES ('Nissastigen', '6', '12841', 5)
INSERT INTO CustomerAddresses VALUES ('Nissastigen', '6', '12841', 6)
INSERT INTO CustomerAddresses VALUES ('Nissastigen', '6', '12841', 7)


INSERT INTO Projects VALUES ('Databasteknik', 'Beskrivning av Databasteknik...', 170000, 1, 2,1)
INSERT INTO Projects VALUES ('Nackademin Skolportal', 'Ny skolportal för Nackademin...', 300000, 1, 1,5)
INSERT INTO Projects VALUES ('Opala', 'Nisses herrmode... blabla', 1950000, 4, 3,6)

INSERT INTO ProjectServices VALUES (1, 1, 180);
INSERT INTO ProjectServices VALUES (2, 2, 300);
INSERT INTO ProjectServices VALUES (2, 3, 155);
INSERT INTO ProjectServices VALUES (2, 4, 200);
INSERT INTO ProjectServices VALUES (3, 3, 600);

INSERT INTO ProjectSchedules VALUES ('2019-03-01', '2019-10-20', 3);
INSERT INTO ProjectSchedules VALUES ('2025-01-15', '2025-03-02', 1)
INSERT INTO ProjectSchedules VALUES ('2026-10-17', '2027-05-28', 2);





