-- liquibase formatted sql
-- changeset senlin:0 context:pet

-- docker run --name mysql -e MYSQL_ROOT_PASSWORD=senlin -p 3306:3306 -d mysql:8.0.32
-- create database should be executed manually, example as below:
-- create database senlin_wu_pet default charset utf8mb4 collate utf8mb4_zh_0900_as_cs;
create table change_data_capture
(
    id          bigint      not null auto_increment,
    entity_id   bigint      not null comment 'change entity id',
    entity_type varchar(30) not null comment 'change entity type',
    type        varchar(30) not null comment 'operation type, Add/Update/Delete/CustomOperation',
    change_user varchar(50) not null comment 'change user',
    change_time datetime    not null comment 'change time',
    change_data json        not null comment 'change data',
    month       char(4)     not null comment 'month',
    primary key (id, month)
)
    comment 'change data capture table' partition by key (month);

create index idx_change_data_capture_entity_id on change_data_capture (entity_id, change_time);