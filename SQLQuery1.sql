﻿CREATE TABLE Music
(
	id int identity primary key,
	name nvarchar(200),
	author nvarchar(200),
	category_id int,
	description nvarchar(200)
)


CREATE TABLE Category
(
	id int identity primary key,
	category nvarchar(200)
)


INSERT INTO Category(category)
VALUES
('POP'),
('ROCK'),
('RAP'),
('JAZZ')

ALTER TABLE Music
ADD CONSTRAINT FK_category_id
FOREIGN KEY (category_id) REFERENCES Category(id)

INSERT INTO Music(name, author, category_id, description)
VALUES
(N'Ласковый май', N'Кузнецов', 1, N'лирическая песня 90 годов'),
(N'LeapSteak', N'9mice', 2, N'песня ни о чем')

SELECT m.id,
		m.name,
		m.author,
		c.category,
		m.description		
FROM Category c JOIN Music m ON c.id = m.category_id

CREATE proc pGetMusic --3
@category_id int
AS
SELECT m.id,
		m.name,
		m.author,
		c.category,
		m.description		
FROM Category c JOIN Music m ON c.id = m.category_id
WHERE (@category_id IS NULL OR m.category_id = @category_id)

CREATE proc pGetCategory
AS
SELECT id,
		category name
FROM Category
ORDER by category