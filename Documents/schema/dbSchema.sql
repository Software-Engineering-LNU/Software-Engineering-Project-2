create table users
(
    id                bigserial not null,
    email             varchar   not null,
    password          varchar   not null,
    full_name         varchar   not null,
    phone_number      varchar   not null,
    is_business_owner bool      not null,

    constraint users_pk primary key (id),
    constraint users_email_uq unique (email),
    constraint users_phone_number_uq unique (phone_number)
);

create table projects
(
    id          bigserial   not null,
    name        varchar(50) not null,
    description text        not null,
    owner_id    bigint      not null,

    constraint projects_pk primary key (id),
    constraint projects_reference_users_fk foreign key (owner_id) references users (id)
);

create table teams
(
    id         bigserial   not null,
    name       varchar(50) not null,
    project_id bigint      not null,

    constraint teams_pk primary key (id),
    constraint projects_reference_projects_fk foreign key (project_id) references projects (id)
);

create table team_members
(
    id      bigserial not null,
    team_id bigint    not null,
    user_id bigint    not null,

    constraint team_members_pk primary key (id),
    constraint team_members_reference_teams_fk foreign key (team_id) references teams (id),
    constraint team_members_reference_users_fk foreign key (user_id) references users (id)
);

create table positions
(
    id   bigserial   not null,
    name varchar(50) not null,

    constraint positions_pk primary key (id)
);

create table permissions
(
    id   bigserial    not null,
    name varchar(150) not null,

    constraint permissions_pk primary key (id)
);

create table position_permissions
(
    id            bigserial not null,
    position_id   bigint    not null,
    permission_id bigint    not null,

    constraint position_permissions_pk primary key (id),
    constraint position_permissions_reference_positions_fk foreign key (position_id) references positions (id),
    constraint position_permissions_reference_permissions_fk foreign key (permission_id) references permissions (id)
);

create table project_members
(
    id          bigserial     not null,
    project_id  bigint        not null,
    user_id     bigint        not null,
    position_id bigint        not null,
    salary      numeric(8, 2) not null,

    constraint project_members_permissions_pk primary key (id),
    constraint project_members_reference_projects_fk foreign key (project_id) references projects (id),
    constraint project_members_reference_users_fk foreign key (user_id) references users (id),
    constraint project_members_reference_positions_fk foreign key (position_id) references positions (id)
);

create table tasks
(
    id           bigserial   not null,
    name         varchar(50) not null,
    description  text        not null,
    estimation   int         not null,
    status       varchar     not null,
    team_id      bigint      not null,
    user_id      bigint      not null,

    constraint tasks_pk primary key (id),
    constraint tasks_reference_teams_fk foreign key (team_id) references teams (id),
    constraint tasks_reference_users_fk foreign key (user_id) references users (id)
);
