-- Create users table
CREATE TABLE IF NOT EXISTS public.users (
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    firstname character(50) NOT NULL,
    lastname character(50) NOT NULL,
    username character(50) NOT NULL,
    email text NOT NULL,
    password_hash text NOT NULL,
    salt text NOT NULL,
    profile_picture_url text NOT NULL,
    bio text NOT NULL,
    created_at timestamp with time zone DEFAULT Now(),
    updated_at timestamp with time zone DEFAULT Now()
);

-- Create posts table
CREATE TABLE IF NOT EXISTS public.posts (
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    user_id bigint NOT NULL,
    caption text NOT NULL,
    image_url text NOT NULL,
    created_at timestamp without time zone NOT NULL DEFAULT Now()
);

-- Create comments table
CREATE TABLE IF NOT EXISTS public.comments (
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    post_id bigint NOT NULL,
    user_id bigint NOT NULL,
    text text NOT NULL,
    created_at timestamp with time zone NOT NULL DEFAULT Now()
);

-- Create likes table
CREATE TABLE IF NOT EXISTS public.likes (
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    post_id bigint NOT NULL,
    user_id bigint NOT NULL,
    created_at timestamp with time zone NOT NULL DEFAULT Now()
);

-- Create followers table
CREATE TABLE IF NOT EXISTS public.followers (
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    user_id bigint NOT NULL,
    follower_user_id bigint NOT NULL,
    created_at timestamp without time zone NOT NULL DEFAULT Now()
);

-- Create direct_conversations table
CREATE TABLE IF NOT EXISTS public.direct_conversations (
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    user1_id bigint NOT NULL,
    user2_id bigint NOT NULL,
    last_message_id bigint NOT NULL,
    created_at timestamp with time zone NOT NULL DEFAULT Now()
);

-- Create direct_messages table
CREATE TABLE IF NOT EXISTS public.direct_messages (
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    conversation_id bigint NOT NULL,
    sender_id bigint NOT NULL,
    recipient_id bigint NOT NULL,
    message_text text NOT NULL,
    sent_at timestamp with time zone NOT NULL DEFAULT Now()
);

-- View to get user's posts with comments, likes, and image_url
CREATE VIEW user_posts_with_details AS
SELECT
    p.*,
    u.username AS author_username,
    c.text AS comment_text,
    l.user_id AS liked_by_user_id,
    p.image_url AS post_image_url
FROM
    posts p
JOIN
    users u ON p.user_id = u.id
LEFT JOIN
    comments c ON p.id = c.post_id
LEFT JOIN
    likes l ON p.id = l.post_id;

-- View to get direct conversations with participants and image_url
CREATE VIEW direct_conversations_with_participants AS
SELECT
    dc.*,
    u1.username AS user1_username,
    u2.username AS user2_username
FROM
    direct_conversations dc
JOIN
    users u1 ON dc.user1_id = u1.id
JOIN
    users u2 ON dc.user2_id = u2.id;

-- View to get direct messages with sender and recipient details
CREATE VIEW direct_messages_with_details AS
SELECT
    dm.*,
    sender.username AS sender_username,
    recipient.username AS recipient_username
FROM
    direct_messages dm
JOIN
    users sender ON dm.sender_id = sender.id
JOIN
    users recipient ON dm.recipient_id = recipient.id;

-- View to get a user's followers
CREATE VIEW user_followers AS
SELECT
    u.*,
    f.created_at AS followed_at
FROM
    users u
JOIN
    followers f ON u.id = f.user_id;

-- View to get users and the number of followers they have
CREATE VIEW users_with_followers_count AS
SELECT
    u.*,
    COUNT(f.id) AS followers_count
FROM
    users u
LEFT JOIN
    followers f ON u.id = f.user_id
GROUP BY
    u.id;

-- View to get a user's posts with their comments count, likes count, and image_url
CREATE VIEW user_posts_with_counts AS
SELECT
    p.*,
    COUNT(c.id) AS comments_count,
    COUNT(l.id) AS likes_count,
    p.image_url AS post_image_url
FROM
    posts p
LEFT JOIN
    comments c ON p.id = c.post_id
LEFT JOIN
    likes l ON p.id = l.post_id
GROUP BY
    p.id;

-- Add foreign key constraints

ALTER TABLE IF EXISTS public.posts
    ADD FOREIGN KEY (user_id)
    REFERENCES public.users (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;

ALTER TABLE IF EXISTS public.comments
    ADD FOREIGN KEY (post_id)
    REFERENCES public.posts (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;

ALTER TABLE IF EXISTS public.comments
    ADD FOREIGN KEY (user_id)
    REFERENCES public.users (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;

ALTER TABLE IF EXISTS public.likes
    ADD FOREIGN KEY (post_id)
    REFERENCES public.posts (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;

ALTER TABLE IF EXISTS public.likes
    ADD FOREIGN KEY (user_id)
    REFERENCES public.users (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;

ALTER TABLE IF EXISTS public.followers
    ADD FOREIGN KEY (user_id)
    REFERENCES public.users (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;

ALTER TABLE IF EXISTS public.followers
    ADD FOREIGN KEY (follower_user_id)
    REFERENCES public.users (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;

ALTER TABLE IF EXISTS public.direct_conversations
    ADD FOREIGN KEY (user1_id)
    REFERENCES public.users (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;

ALTER TABLE IF EXISTS public.direct_conversations
    ADD FOREIGN KEY (user2_id)
    REFERENCES public.users (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;

ALTER TABLE IF EXISTS public.direct_messages
    ADD FOREIGN KEY (conversation_id)
    REFERENCES public.direct_conversations (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;

ALTER TABLE IF EXISTS public.direct_messages
    ADD FOREIGN KEY (sender_id)
    REFERENCES public.users (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;
