INSERT INTO "RpgSkills" ("Name")
VALUES
  ('Creation'),
  ('Mending'),
  ('Maintaining'),
  ('Destruction');

INSERT INTO "RpgQuests" ("Name", "Time", "Xp", "Money")
VALUES
  ('Art',         30, 100,  10),
  ('Music',       30, 100,  10),
  ('Programming', 60, 700,  80),
  ('Design',      30, 100,  10),
  ('Exercise',    45, 400,  0),
  ('Chores',      5,  40,   0),
  ('Plumbing',    30, 100,  30);

INSERT INTO "RpgUpgrades" ("Name", "Level", "Cost", "Description")
VALUES
  ('Multitasking',      1, 200,  'Allows character to manage two quests at the same time.'),
  ('Hyper-Focus',       1, 400,  'Doing the two quests of the same skill type consecutively costs 20% less time.'),
  ('Multidisciplinary', 1, 300,  'Quests give extra 10% xp'),
  ('Entrepreneur',      1, 300,  'Quests give extra 10% money.');

INSERT INTO "RpgItems" ("Name", "Cost", "Description")
VALUES
  ('Boots',   3000, 'They look cool, especially in music videos.'),
  ('Jacket',  8000, 'Everyone things you`re really cool when you wear this.'),
  ('Gloves',  3000, 'Flashy and fingerless.'),
  ('Hat',     9000, 'It does look silly, and it is expensive.');
