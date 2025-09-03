CREATE TABLE "RpgCharacters" (
  "Id" BIGSERIAL PRIMARY KEY,
  "UserId" TEXT,
  "Name" VARCHAR(255) NOT NULL,
  "Xp" INT,
  "Money" INT,
  FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id")
);

CREATE TABLE "RpgSkills" (
  "Id" BIGSERIAL PRIMARY KEY,
  "Name" VARCHAR(255) NOT NULL
);

CREATE TABLE "RpgCharacterSkills" (
  "CharacterId" INT,
  "SkillId" INT,
  FOREIGN KEY ("CharacterId") REFERENCES "RpgCharacters" ("Id"),
  FOREIGN KEY ("SkillId") REFERENCES "RpgSkills" ("Id")
);

CREATE TABLE "RpgQuests" (
  "Id" BIGSERIAL PRIMARY KEY,
  "Name" VARCHAR(255) NOT NULL,
  "Time" INT DEFAULT 15,
  "Xp" INT,
  "Money" INT
);

CREATE TABLE "RpgQuestSkills" (
  "SkillId" INT,
  "QuestId" INT,
  FOREIGN KEY ("SkillId") REFERENCES "RpgSkills" ("Id"),
  FOREIGN KEY ("QuestId") REFERENCES "RpgQuests" ("Id")
);

CREATE TABLE "RpgActiveQuests" (
  "CharacterId" INT,
  "QuestId" INT,
  FOREIGN KEY ("CharacterId") REFERENCES "RpgCharacters" ("Id"),
  FOREIGN KEY ("QuestId") REFERENCES "RpgQuests" ("Id")
);

CREATE TABLE "RpgUpgrades" (
  "Id" BIGSERIAL PRIMARY KEY,
  "Level" INT,
  "Cost" INT,
  "Name" VARCHAR(255) NOT NULL,
  "Description" VARCHAR(1000) NOT NULL
);

CREATE TABLE "RpgAppliedUpgrades" (
  "CharacterId" INT,
  "UpgradeId" INT,
  FOREIGN KEY ("CharacterId") REFERENCES "RpgCharacters" ("Id"),
  FOREIGN KEY ("UpgradeId") REFERENCES "RpgUpgrades" ("Id")
);

CREATE TABLE "RpgItems" (
  "Id" BIGSERIAL PRIMARY KEY,
  "Cost" INT,
  "Name" VARCHAR(255) NOT NULL,
  "Description" VARCHAR(1000) NOT NULL
);

CREATE TABLE "RpgOwnedItems" (
  "CharacterId" INT,
  "ItemId" INT,
  FOREIGN KEY ("CharacterId") REFERENCES "RpgCharacters" ("Id"),
  FOREIGN KEY ("ItemId") REFERENCES "RpgItems" ("Id")
);
