  IF EXISTS(SELECT 1 FROM information_schema.tables 
  WHERE table_name = '
__EFMigrationsHistory' AND table_schema = DATABASE()) 
BEGIN
CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

END;

CREATE TABLE `categories` (
    `Name` varchar(255) NOT NULL,
    PRIMARY KEY (`Name`)
);

CREATE TABLE `instructors` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Email` text NOT NULL,
    `IsActivated` bit NOT NULL,
    `Name` text NOT NULL,
    `Password` text NOT NULL,
    `PhoneNumber` text NOT NULL,
    `Surname` text NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `localizations` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `voivodeship` text NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `marketStatuses` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Status` varchar(255) NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `roles` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `RoleName` text NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Tags` (
    `Name` varchar(255) NOT NULL,
    PRIMARY KEY (`Name`)
);

CREATE TABLE `users` (
    `PhoneNumber` varchar(16) NOT NULL,
    `Name` text NOT NULL,
    `Surname` text NOT NULL,
    PRIMARY KEY (`PhoneNumber`)
);

CREATE TABLE `Reminders` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Description` text NULL,
    `DueDate` datetime NOT NULL,
    `InstructorId` int NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Reminders_instructors_InstructorId` FOREIGN KEY (`InstructorId`) REFERENCES `instructors` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `trainings` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `CategoryName` varchar(255) NOT NULL,
    `Description` varchar(2000) NOT NULL,
    `InsertDate` datetime NOT NULL,
    `InstructorId` int NOT NULL,
    `LastUpdate` datetime NOT NULL,
    `LocalizationId` int NOT NULL,
    `MarketStatusId` int NOT NULL,
    `RegisterSince` datetime NOT NULL,
    `RegisterTo` datetime NOT NULL,
    `Title` varchar(255) NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_trainings_categories_CategoryName` FOREIGN KEY (`CategoryName`) REFERENCES `categories` (`Name`) ON DELETE CASCADE,
    CONSTRAINT `FK_trainings_instructors_InstructorId` FOREIGN KEY (`InstructorId`) REFERENCES `instructors` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_trainings_localizations_LocalizationId` FOREIGN KEY (`LocalizationId`) REFERENCES `localizations` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_trainings_marketStatuses_MarketStatusId` FOREIGN KEY (`MarketStatusId`) REFERENCES `marketStatuses` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `instructor_roles` (
    `InstructorId` int NOT NULL,
    `RoleId` int NOT NULL,
    PRIMARY KEY (`InstructorId`, `RoleId`),
    CONSTRAINT `FK_instructor_roles_instructors_InstructorId` FOREIGN KEY (`InstructorId`) REFERENCES `instructors` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_instructor_roles_roles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `UserLog` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Date` datetime NOT NULL,
    `Description` text NOT NULL,
    `UserPhoneNumber` varchar(16) NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_UserLog_users_UserPhoneNumber` FOREIGN KEY (`UserPhoneNumber`) REFERENCES `users` (`PhoneNumber`) ON DELETE CASCADE
);

CREATE TABLE `entries` (
    `TrainingId` int NOT NULL,
    `UserPhoneNumber` varchar(16) NOT NULL,
    `InsertDate` datetime NOT NULL,
    PRIMARY KEY (`TrainingId`, `UserPhoneNumber`),
    CONSTRAINT `FK_entries_trainings_TrainingId` FOREIGN KEY (`TrainingId`) REFERENCES `trainings` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_entries_users_UserPhoneNumber` FOREIGN KEY (`UserPhoneNumber`) REFERENCES `users` (`PhoneNumber`) ON DELETE CASCADE
);

CREATE TABLE `training_tags` (
    `TrainingId` int NOT NULL,
    `TagName` varchar(255) NOT NULL,
    PRIMARY KEY (`TrainingId`, `TagName`),
    CONSTRAINT `FK_training_tags_Tags_TagName` FOREIGN KEY (`TagName`) REFERENCES `Tags` (`Name`) ON DELETE CASCADE,
    CONSTRAINT `FK_training_tags_trainings_TrainingId` FOREIGN KEY (`TrainingId`) REFERENCES `trainings` (`Id`) ON DELETE CASCADE
);

CREATE INDEX `IX_entries_UserPhoneNumber` ON entries (`UserPhoneNumber`);

CREATE INDEX `IX_instructor_roles_RoleId` ON instructor_roles (`RoleId`);

CREATE UNIQUE INDEX `IX_marketStatuses_Status` ON marketStatuses (`Status`);

CREATE INDEX `IX_Reminders_InstructorId` ON Reminders (`InstructorId`);

CREATE INDEX `IX_training_tags_TagName` ON training_tags (`TagName`);

CREATE INDEX `IX_trainings_CategoryName` ON trainings (`CategoryName`);

CREATE INDEX `IX_trainings_InstructorId` ON trainings (`InstructorId`);

CREATE INDEX `IX_trainings_LocalizationId` ON trainings (`LocalizationId`);

CREATE INDEX `IX_trainings_MarketStatusId` ON trainings (`MarketStatusId`);

CREATE INDEX `IX_UserLog_UserPhoneNumber` ON UserLog (`UserPhoneNumber`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180322184458_init_v2', '2.0.1-rtm-125');

INSERT INTO localizations (voivodeship) VALUES ('Pomorskie')

INSERT INTO localizations (voivodeship) VALUES ('Mazowieckie')

INSERT INTO localizations (voivodeship) VALUES ('Lubelskie')

INSERT INTO marketstatuses (status) VALUES ('Bezrobotny')

INSERT INTO marketstatuses (status) VALUES ('Aktywny')

INSERT INTO marketstatuses (status) VALUES ('Wszystkie')

INSERT INTO categories (name) VALUES ('Jezyki')

INSERT INTO categories (name) VALUES ('Inne')

INSERT INTO categories (name) VALUES ('Mechanika')

INSERT INTO tags (name) VALUES ('Przyspieszony')

INSERT INTO tags (name) VALUES ('Native speaker')

INSERT INTO tags (name) VALUES ('Hiszpanski')

INSERT INTO roles (roleName) VALUES ('Admin')

INSERT INTO roles (roleName) VALUES ('Basic')

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180322184803_populate', '2.0.1-rtm-125');

ALTER TABLE `instructors` ADD `IsAdmin` bit NOT NULL DEFAULT False;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180322193537_instructor admin', '2.0.1-rtm-125');

ALTER TABLE `users` ADD `Age` int NOT NULL DEFAULT 0;

ALTER TABLE `users` ADD `Email` varchar(100) NOT NULL DEFAULT '';

ALTER TABLE `users` ADD `LocalizationId` int NOT NULL DEFAULT 0;

CREATE INDEX `IX_users_LocalizationId` ON users (`LocalizationId`);

ALTER TABLE `users` ADD CONSTRAINT `FK_users_localizations_LocalizationId` FOREIGN KEY (`LocalizationId`) REFERENCES `localizations` (`Id`) ON DELETE CASCADE;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180322222221_User age, email and localization', '2.0.1-rtm-125');

ALTER TABLE `users` ADD `MarketStatusId` int NULL;

CREATE INDEX `IX_users_MarketStatusId` ON users (`MarketStatusId`);

ALTER TABLE `users` ADD CONSTRAINT `FK_users_marketStatuses_MarketStatusId` FOREIGN KEY (`MarketStatusId`) REFERENCES `marketStatuses` (`Id`) ON DELETE RESTRICT;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180323001204_User market status', '2.0.1-rtm-125');

ALTER TABLE `users` ADD `LastUpdate` datetime NOT NULL DEFAULT '0001-01-01 00:00:00.000';

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180323212356_User last update', '2.0.1-rtm-125');

DROP TABLE `instructor_roles`;

DROP TABLE `roles`;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180327171033_Unused tables cleanup', '2.0.1-rtm-125');

ALTER TABLE `users` DROP COLUMN `Age`;

ALTER TABLE `users` ADD `Birthday` datetime NOT NULL DEFAULT '0001-01-01 00:00:00.000';

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180327171403_User birthday', '2.0.1-rtm-125');

ALTER TABLE `users` ADD `AreaOfResidenceId` int NOT NULL DEFAULT 0;

ALTER TABLE `users` ADD `EducationId` int NOT NULL DEFAULT 0;

ALTER TABLE `users` ADD `SexId` int NOT NULL DEFAULT 0;

ALTER TABLE `users` ADD `hasDisability` bit NOT NULL DEFAULT False;

CREATE TABLE `areas_of_residence` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `AreaType` varchar(16) NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `educations` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `EducationType` varchar(32) NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `notes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Description` varchar(1000) NOT NULL,
    `UserPhoneNumber` varchar(16) NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_notes_users_UserPhoneNumber` FOREIGN KEY (`UserPhoneNumber`) REFERENCES `users` (`PhoneNumber`) ON DELETE CASCADE
);

CREATE TABLE `sexes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(16) NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE INDEX `IX_users_AreaOfResidenceId` ON users (`AreaOfResidenceId`);

CREATE INDEX `IX_users_EducationId` ON users (`EducationId`);

CREATE INDEX `IX_users_SexId` ON users (`SexId`);

CREATE INDEX `IX_notes_UserPhoneNumber` ON notes (`UserPhoneNumber`);

ALTER TABLE `users` ADD CONSTRAINT `FK_users_areas_of_residence_AreaOfResidenceId` FOREIGN KEY (`AreaOfResidenceId`) REFERENCES `areas_of_residence` (`Id`) ON DELETE CASCADE;

ALTER TABLE `users` ADD CONSTRAINT `FK_users_educations_EducationId` FOREIGN KEY (`EducationId`) REFERENCES `educations` (`Id`) ON DELETE CASCADE;

ALTER TABLE `users` ADD CONSTRAINT `FK_users_sexes_SexId` FOREIGN KEY (`SexId`) REFERENCES `sexes` (`Id`) ON DELETE CASCADE;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180327180321_New user fields', '2.0.1-rtm-125');

INSERT INTO sexes (Name) VALUES ('Kobieta')

INSERT INTO sexes (Name) VALUES ('Meżczyzna')

INSERT INTO areas_of_residence (AreaType) VALUES ('Wiejski')

INSERT INTO areas_of_residence (AreaType) VALUES ('Miejski')

INSERT INTO areas_of_residence (AreaType) VALUES ('Wiejsko-Miejski')

INSERT INTO educations (EducationType) VALUES ('Podstawowe')

INSERT INTO educations (EducationType) VALUES ('Gimnazjalne')

INSERT INTO educations (EducationType) VALUES ('Zasadnicze zawodowe')

INSERT INTO educations (EducationType) VALUES ('Ponadgimnazjalne (średnie)')

INSERT INTO educations (EducationType) VALUES ('Policealne (np. studium)')

INSERT INTO educations (EducationType) VALUES ('Wyższe')

DELETE FROM marketstatuses WHERE status IN ('Bezrobotny','Aktywny','Wszystkie')

INSERT INTO marketstatuses (status) VALUES ('Pracujący')

INSERT INTO marketstatuses (status) VALUES ('Bierny zawodowo')

INSERT INTO marketstatuses (status) VALUES ('Inne')

INSERT INTO marketstatuses (status) VALUES ('Emeryt')

INSERT INTO marketstatuses (status) VALUES ('Uczący się')

INSERT INTO marketstatuses (status) VALUES ('Bezrobotny–niepracujący zarejestrowany w PUP')

INSERT INTO marketstatuses (status) VALUES ('Niepracujący niezarejestrowany w PUP')

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180327180857_populate sex, education, areaofresidence, marketStatus', '2.0.1-rtm-125');

ALTER TABLE `users` ADD `CountyId` int NOT NULL DEFAULT 0;

CREATE TABLE `voivodeships` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `VoivodeshipName` varchar(64) NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `counties` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `CountyName` varchar(255) NOT NULL,
    `VoivodeshipId` int NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_counties_voivodeships_VoivodeshipId` FOREIGN KEY (`VoivodeshipId`) REFERENCES `voivodeships` (`Id`) ON DELETE CASCADE
);

CREATE INDEX `IX_users_CountyId` ON users (`CountyId`);

CREATE INDEX `IX_counties_VoivodeshipId` ON counties (`VoivodeshipId`);

ALTER TABLE `users` ADD CONSTRAINT `FK_users_counties_CountyId` FOREIGN KEY (`CountyId`) REFERENCES `counties` (`Id`) ON DELETE CASCADE;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180327192805_Counties', '2.0.1-rtm-125');

ALTER TABLE `users` DROP foreign key `FK_users_localizations_LocalizationId`

DROP INDEX IX_users_LocalizationId ON users;

ALTER TABLE `users` DROP COLUMN `LocalizationId`;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180327194646_Removed user localization', '2.0.1-rtm-125');

ALTER TABLE `users` DROP foreign key `FK_users_counties_CountyId`

ALTER TABLE users MODIFY `CountyId` int NOT NULL;

ALTER TABLE `users` ADD `VoivodeshipId` int NOT NULL DEFAULT 0;

CREATE INDEX `IX_users_VoivodeshipId` ON users (`VoivodeshipId`);

ALTER TABLE `users` ADD CONSTRAINT `FK_users_counties_CountyId` FOREIGN KEY (`CountyId`) REFERENCES `counties` (`Id`) ON DELETE RESTRICT;

ALTER TABLE `users` ADD CONSTRAINT `FK_users_voivodeships_VoivodeshipId` FOREIGN KEY (`VoivodeshipId`) REFERENCES `voivodeships` (`Id`) ON DELETE CASCADE;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180327224619_User county optional, voivodeship required', '2.0.1-rtm-125');

ALTER TABLE `trainings` ADD `VoivodeshipId` int NOT NULL DEFAULT 0;

CREATE TABLE `training_localizations` (
    `TrainingId` int NOT NULL,
    `CountyId` int NOT NULL,
    PRIMARY KEY (`TrainingId`, `CountyId`),
    CONSTRAINT `FK_training_localizations_counties_CountyId` FOREIGN KEY (`CountyId`) REFERENCES `counties` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_training_localizations_trainings_TrainingId` FOREIGN KEY (`TrainingId`) REFERENCES `trainings` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `training_marketstatuses` (
    `TrainingId` int NOT NULL,
    `MarketStatusId` int NOT NULL,
    PRIMARY KEY (`TrainingId`, `MarketStatusId`),
    CONSTRAINT `FK_training_marketstatuses_marketStatuses_MarketStatusId` FOREIGN KEY (`MarketStatusId`) REFERENCES `marketStatuses` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_training_marketstatuses_trainings_TrainingId` FOREIGN KEY (`TrainingId`) REFERENCES `trainings` (`Id`) ON DELETE CASCADE
);

CREATE INDEX `IX_trainings_VoivodeshipId` ON trainings (`VoivodeshipId`);

CREATE INDEX `IX_training_localizations_CountyId` ON training_localizations (`CountyId`);

CREATE INDEX `IX_training_marketstatuses_MarketStatusId` ON training_marketstatuses (`MarketStatusId`);

ALTER TABLE `trainings` ADD CONSTRAINT `FK_trainings_voivodeships_VoivodeshipId` FOREIGN KEY (`VoivodeshipId`) REFERENCES `voivodeships` (`Id`) ON DELETE CASCADE;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180327233652_Training multiple counties and market statuses', '2.0.1-rtm-125');

