INSERT INTO "RpgSkills" ("Name")
VALUES
  ('Creation'),
  ('Mending'),
  ('Maintaining'),
  ('Destruction');

INSERT INTO "RpgQuests" ("Name", "Time", "Xp", "Money")
VALUES
  ('Art',         30, 10,  10),
  ('Music',       30, 10,  10),
  ('Programming', 60, 70,  80),
  ('Design',      30, 10,  10),
  ('Exercise',    45, 40,  0),
  ('Chores',      5,  4,   0),
  ('Plumbing',    30, 10,  30);

INSERT INTO "RpgQuestSkills"
VALUES
  (1, 1),
  (2, 1),
  (3, 1),
  (3, 2),
  (3, 3),
  (4, 1),
  (5, 2),
  (5, 3),
  (6, 2),
  (6, 3),
  (7, 2),
  (7, 3);


INSERT INTO "RpgUpgrades" ("Name", "Level", "Cost", "Description")
VALUES
  ('Multitasking',      1, 200,  'Allows character to manage two quests at the same time.'),
  ('Hyper-Focus',       1, 400,  'Doing the two quests of the same skill type consecutively costs 20% less time.'),
  ('Multidisciplinary', 1, 300,  'Quests give extra 10% xp'),
  ('Entrepreneur',      1, 300,  'Quests give extra 10% money.'),
  ('Multitasking',      2, 600,  'Allows character to manage three quests at the same time.'),
  ('Hyper-Focus',       2, 800,  'Doing the three quests of the same skill type consecutively costs 40% less time.'),
  ('Multidisciplinary', 2, 900,  'Quests give extra 20% xp'),
  ('Entrepreneur',      2, 900,  'Quests give extra 20% money.'),
  ('Multitasking',      3, 1800,  'Allows character to manage four quests at the same time.'),
  ('Hyper-Focus',       3, 1600,  'Doing the five quests of the same skill type consecutively costs 80% less time.'),
  ('Multidisciplinary', 3, 2700,  'Quests give extra 40% xp'),
  ('Entrepreneur',      3, 2700,  'Quests give extra 40% money.'),
  ('Multitasking',      4, 6400,  'Allows character to manage five quests at the same time.'),
  ('Hyper-Focus',       4, 3200,  'Doing the eight quests of the same skill type consecutively costs 160% less time.'),
  ('Multidisciplinary', 4, 9000,  'Quests give extra 80% xp'),
  ('Entrepreneur',      4, 9000,  'Quests give extra 80% money.');

INSERT INTO "RpgItems" ("Name", "Cost", "Description")
VALUES
  ('Boots',   3000, 'They look cool, especially in music videos.'),
  ('Jacket',  8000, 'Everyone things you`re really cool when you wear this.'),
  ('Gloves',  3000, 'Flashy and fingerless.'),
  ('Hat',     9000, 'It does look silly, and it is expensive.');
