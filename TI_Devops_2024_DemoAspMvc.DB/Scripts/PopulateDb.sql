-- Insertion des auteurs
INSERT INTO [dbo].[Author] (Firstname, Lastname, Pen_name, Birthdate)
VALUES 
('George', 'Orwell', 'George Orwell', '1903-06-25'),
('Jane', 'Austen', NULL, '1775-12-16'),
('Mark', 'Twain', 'Samuel Clemens', '1835-11-30'),
('Harper', 'Lee', NULL, '1926-04-28'),
('F. Scott', 'Fitzgerald', NULL, '1896-09-24'),
('J.K.', 'Rowling', 'Robert Galbraith', '1965-07-31'),
('J.R.R.', 'Tolkien', NULL, '1892-01-03'),
('Agatha', 'Christie', NULL, '1890-09-15'),
('Leo', 'Tolstoy', NULL, '1828-09-09'),
('Gabriel', 'Garcia Marquez', NULL, '1927-03-06');

-- Insertion des livres
INSERT INTO [dbo].[Book] (ISBN, Title, Description, Publish_date, Author_id)
VALUES
('9780451524935', '1984', 'Dystopian novel set in a totalitarian society ruled by Big Brother.', '1949-06-08', (SELECT Id FROM [dbo].[Author] WHERE Firstname = 'George' AND Lastname = 'Orwell')),
('9780141439518', 'Pride and Prejudice', 'Romantic novel that critiques the British landed gentry at the end of the 18th century.', '1813-01-28', (SELECT Id FROM [dbo].[Author] WHERE Firstname = 'Jane' AND Lastname = 'Austen')),
('9780486280615', 'Adventures of Huckleberry Finn', 'The story of a young boy and a runaway slave on their journey down the Mississippi River.', '1884-12-10', (SELECT Id FROM [dbo].[Author] WHERE Firstname = 'Mark' AND Lastname = 'Twain')),
('9780061120084', 'To Kill a Mockingbird', 'A novel about the serious issues of rape and racial inequality.', '1960-07-11', (SELECT Id FROM [dbo].[Author] WHERE Firstname = 'Harper' AND Lastname = 'Lee')),
('9780743273565', 'The Great Gatsby', 'A novel about the American dream and the roaring twenties.', '1925-04-10', (SELECT Id FROM [dbo].[Author] WHERE Firstname = 'F. Scott' AND Lastname = 'Fitzgerald')),
('9780545582889', 'Harry Potter and the Sorcerer''s Stone', 'The first book in the Harry Potter series.', '1997-06-26', (SELECT Id FROM [dbo].[Author] WHERE Firstname = 'J.K.' AND Lastname = 'Rowling')),
('9780618640157', 'The Lord of the Rings: The Fellowship of the Ring', 'The first volume in the Lord of the Rings trilogy.', '1954-07-29', (SELECT Id FROM [dbo].[Author] WHERE Firstname = 'J.R.R.' AND Lastname = 'Tolkien')),
('9780062073488', 'Murder on the Orient Express', 'A Hercule Poirot mystery novel.', '1934-01-01', (SELECT Id FROM [dbo].[Author] WHERE Firstname = 'Agatha' AND Lastname = 'Christie')),
('9780192833983', 'War and Peace', 'A novel that chronicles the history of the French invasion of Russia.', '1869-01-01', (SELECT Id FROM [dbo].[Author] WHERE Firstname = 'Leo' AND Lastname = 'Tolstoy')),
('9780060883287', 'One Hundred Years of Solitude', 'A multi-generational story of the Buendía family.', '1967-05-30', (SELECT Id FROM [dbo].[Author] WHERE Firstname = 'Gabriel' AND Lastname = 'Garcia Marquez'));
