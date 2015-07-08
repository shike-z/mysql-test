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
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `uuid` char(36) NOT NULL DEFAULT '',
  `name` varchar(20) NOT NULL DEFAULT '',
  `city` varchar(20) NOT NULL DEFAULT '',
  `note` varchar(200) NOT NULL DEFAULT 'abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghij',
  PRIMARY KEY (`uuid`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 插入10万条后

-- 
explain SELECT count(*) FROM test.t_user1;
explain SELECT count(*) FROM test.t_user2;

-- 
explain SELECT * FROM test.t_user1 where id between 1000 and 2000;
explain SELECT * FROM test.t_user2 where id between 1000 and 2000;

-- 
explain SELECT * FROM test.t_user1 where uuid='d1814311-3160-48e8-afd1-bb75adad95eb';
explain SELECT * FROM test.t_user2 where uuid='0e91f1e9-4115-4b7d-a30d-8c21b6cb171c';

-- 
select table_name,data_length,index_length,table_rows from information_schema.tables where table_schema='test';
