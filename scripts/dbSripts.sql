CREATE TABLE bank_user(
	userID BIGSERIAL PRIMARY KEY NOT NULL ,
	firstName VARCHAR(32) NOT NULL,
	lastName VARCHAR (32) NOT NULL,
	email VARCHAR (255) NOT NULL,
	password VARCHAR (32) NOT NULL,
	unique(email)

);