CREATE SCHEMA `test` ;

use `test`;

CREATE TABLE `t_user1` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `uuid` char(36) NOT NULL DEFAULT '',
  `name` varchar(20) NOT NULL DEFAULT '',
  `city` varchar(20) NOT NULL DEFAULT '',
  `note` varchar(200) NOT NULL DEFAULT 'abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghij',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uuid_UNIQUE` (`uuid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


CREATE TABLE `t_user2` (
  `uuid` char(36) NOT NULL DEFAULT '',
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(20) NOT NULL DEFAULT '',
  `city` varchar(20) NOT NULL DEFAULT '',
  `note` varchar(200) NOT NULL DEFAULT 'abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghij',
  PRIMARY KEY (`uuid`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


CREATE TABLE `t_user3` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `uuid` char(36) NOT NULL DEFAULT '',
  `name` varchar(20) NOT NULL DEFAULT '',
  `city` varchar(20) NOT NULL DEFAULT '',
  `note` varchar(200) NOT NULL DEFAULT 'abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghij',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `t_user4` (
  `uuid` char(36) NOT NULL DEFAULT '',
  `id` int(11) NOT NULL DEFAULT 0,
  `name` varchar(20) NOT NULL DEFAULT '',
  `city` varchar(20) NOT NULL DEFAULT '',
  `note` varchar(200) NOT NULL DEFAULT 'abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghij',
  PRIMARY KEY (`uuid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 插入10万条数据

-- 解释命令
explain SELECT count(*) FROM test.t_user1;
explain SELECT count(*) FROM test.t_user2;
explain SELECT count(*) FROM test.t_user3;
explain SELECT count(*) FROM test.t_user4;

explain SELECT name,city,note FROM test.t_user1 where id between 10000 and 20000 and uuid like '%a%' and name like 'name1%';
explain SELECT name,city,note FROM test.t_user2 where id between 10000 and 20000 and uuid like '%a%' and name like 'name1%';
explain SELECT name,city,note FROM test.t_user3 where id between 10000 and 20000 and uuid like '%a%' and name like 'name1%';
explain SELECT name,city,note FROM test.t_user4 where id between 10000 and 20000 and uuid like '%a%' and name like 'name1%';

explain SELECT name,city,note FROM test.t_user1 where uuid like '%a%';
explain SELECT name,city,note FROM test.t_user2 where uuid like '%a%';
explain SELECT name,city,note FROM test.t_user3 where uuid like '%a%';
explain SELECT name,city,note FROM test.t_user4 where uuid like '%a%';

explain SELECT uuid FROM test.t_user1 where uuid like '%a%';
explain SELECT uuid FROM test.t_user2 where uuid like '%a%';
explain SELECT uuid FROM test.t_user3 where uuid like '%a%';
explain SELECT uuid FROM test.t_user4 where uuid like '%a%';

explain SELECT name,city,note FROM test.t_user1 where uuid like '%a%' and name like 'name1%';
explain SELECT name,city,note FROM test.t_user2 where uuid like '%a%' and name like 'name1%';
explain SELECT name,city,note FROM test.t_user3 where uuid like '%a%' and name like 'name1%';
explain SELECT name,city,note FROM test.t_user4 where uuid like '%a%' and name like 'name1%';

-- 查看表信息
select * from information_schema.tables where table_schema='test';

-- 查看表状态
show table status from test;

-- 优化表
optimize table test.t_user1;
optimize table test.t_user2;
optimize table test.t_user3;
optimize table test.t_user4;

-- 删除数据
delete from test.t_user1 where id < 20000;
delete from test.t_user2 where id < 20000;
delete from test.t_user3 where id < 20000;
delete from test.t_user4 where id < 20000 and uuid !='';

-- 再次插入10条数据

show table status from test;