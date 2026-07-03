-- =============================================================================
-- GS1 project — MySQL schema for database: datamodun
-- Generated from C# usage (users, devices, log).
-- Charset utf8mb4 for Vietnamese text (full_name, note, etc.).
-- =============================================================================

CREATE DATABASE IF NOT EXISTS `datamodun`
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_unicode_ci;

USE `datamodun`;

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

DROP TABLE IF EXISTS `log`;
DROP TABLE IF EXISTS `devices`;
DROP TABLE IF EXISTS `users`;

SET FOREIGN_KEY_CHECKS = 1;

-- -----------------------------------------------------------------------------
-- users — Login.cs, Users.cs, UserService.cs, DeviceDAO.GetUserName, log JOIN
-- -----------------------------------------------------------------------------
CREATE TABLE `users` (
  `id`            INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `username`      VARCHAR(100) NOT NULL,
  `password`      VARCHAR(255) NOT NULL,
  `full_name`     VARCHAR(200) NOT NULL,
  `role`          VARCHAR(50)  NOT NULL DEFAULT 'user',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_users_username` (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- -----------------------------------------------------------------------------
-- devices — Add.cs, Devices.cs, DeviceDAO, LogDAO, Dashboard (statusitem)
-- statusitem in app: 'Available' | 'Using' | 'Maintenance'
-- -----------------------------------------------------------------------------
CREATE TABLE `devices` (
  `id`               INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name_item`        VARCHAR(200) NOT NULL,
  `type_item`        VARCHAR(100) NOT NULL,
  `location`         VARCHAR(200) NOT NULL,
  `gs1`              VARCHAR(50)  NOT NULL,
  `statusitem`       VARCHAR(50)  NOT NULL DEFAULT 'Available',
  `current_user_id`  INT UNSIGNED NULL DEFAULT NULL,
  `note`             TEXT NULL,
  `import_date`      DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_devices_gs1` (`gs1`),
  KEY `idx_devices_status` (`statusitem`),
  KEY `idx_devices_current_user` (`current_user_id`),
  CONSTRAINT `fk_devices_current_user`
    FOREIGN KEY (`current_user_id`) REFERENCES `users` (`id`)
    ON DELETE SET NULL
    ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- -----------------------------------------------------------------------------
-- log — Logs.cs, LogDAO.cs, Dashboard recent logs, Scan borrow/return/maintenance
-- -----------------------------------------------------------------------------
CREATE TABLE `log` (
  `id`           INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `user_id`      INT UNSIGNED NOT NULL,
  `device_id`    INT UNSIGNED NOT NULL,
  `action_type`  VARCHAR(100) NOT NULL,
  `time_action`  DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `idx_log_time` (`time_action`),
  KEY `idx_log_user` (`user_id`),
  KEY `idx_log_device` (`device_id`),
  CONSTRAINT `fk_log_user`
    FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_log_device`
    FOREIGN KEY (`device_id`) REFERENCES `devices` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =============================================================================
-- Optional sample data (xóa hoặc sửa mật khẩu theo nhu cầu)
-- =============================================================================

INSERT INTO `users` (`username`, `password`, `full_name`, `role`) VALUES
('admin', 'admin', N'Quản trị hệ thống', 'admin');

-- Thiết bị mẫu (gs1 trùng với code Scan / thử nghiệm)
INSERT INTO `devices` (`name_item`, `type_item`, `location`, `gs1`, `statusitem`, `current_user_id`, `note`, `import_date`) VALUES
(N'Máy tính xách tay', N'Laptop', N'Phòng A', 'GS1001', 'Available', NULL, N'Thiết bị mẫu', NOW()),
(N'MacBook Pro', N'Laptop', N'Lab B', 'GS1010', 'Available', NULL, NULL, NOW()),
(N'Thiết bị WNTD', N'Khác', N'Lab B', 'GS1030', 'Available', NULL, NULL, NOW());
