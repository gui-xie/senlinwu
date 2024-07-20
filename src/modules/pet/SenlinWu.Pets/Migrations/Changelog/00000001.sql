-- liquibase formatted sql
-- changeset senlin:1 context:pet

create table pet
(
    id   bigint      not null,
    name varchar(50) not null comment 'pet name',
    tenant char(4) not null comment 'tenant',
    concurrency_token binary(16) not null comment 'concurrency token',
    create_time datetime not null comment 'create time',
    create_user varchar(50) not null comment 'create user',
    update_time datetime not null comment 'update time',
    update_user varchar(50) not null comment 'update user',
    delete_time datetime not null comment 'delete time',
    delete_user varchar(50) not null comment 'delete user',
    is_delete tinyint not null comment 'is deleted'
) comment 'pet table';