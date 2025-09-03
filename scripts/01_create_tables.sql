-- docker exec -i <container_name> mysql -u root -ppassword <mydb> < /path/to/script.sql


CREATE TABLE Characters (
  id BIGSERIAL PRIMARY KEY,
  user_id TEXT,
  "name" VARCHAR(255) NOT NULL,
  xp INT,
  "money" INT,
  FOREIGN KEY (user_id) REFERENCES AspNetRoles (Id)
);

CREATE TABLE Skills (
  id BIGSERIAL PRIMARY KEY,
  "name" VARCHAR(255) NOT NULL,
);

CREATE TABLE CharacterSkills (
  character_id INT,
  skill_id INT,
  FOREIGN KEY (character_id) REFERENCES Characters (id),
  FOREIGN KEY (skill_id) REFERENCES Skills (id),
);

CREATE TABLE Quests (
  id BIGSERIAL PRIMARY KEY,
  "name" VARCHAR(255) NOT NULL,
  "time" INT DEFAULT 15,
  xp_reward INT,
  money_reward INT,
);

CREATE TABLE ActiveQuests (
  character_id INT,
  quest_id INT,
  FOREIGN KEY (character_id) REFERENCES Characters (id),
  FOREIGN KEY (quest_id) REFERENCES Quests (id),
);

CREATE TABLE Upgrades (
  id BIGSERIAL PRIMARY KEY,
  cost INT,
  "name" VARCHAR(255) NOT NULL,
  "description" VARCHAR(1000) NOT NULL,
);

CREATE TABLE AppliedUpgrades (
  character_id INT,
  upgrade_id INT,
  FOREIGN KEY (character_id) REFERENCES Characters (id),
  FOREIGN KEY (upgrade_id) REFERENCES Upgrades (id),
);

CREATE TABLE Items (
  id BIGSERIAL PRIMARY KEY,
  cost INT,
  "name" VARCHAR(255) NOT NULL,
  "description" VARCHAR(1000) NOT NULL,
);

CREATE TABLE OwnedItems (
  character_id INT,
  item_id INT,
  FOREIGN KEY (character_id) REFERENCES Characters (id),
  FOREIGN KEY (item_id) REFERENCES Items (id),
);
