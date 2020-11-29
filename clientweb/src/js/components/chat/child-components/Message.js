import React from "react";

const Message = ({ content, login, isCurrentUser }) => {
  return (
    <article className={`${isCurrentUser ? 'message-left' : 'message-right'} m-t-15`}>
      <div className="message-title">
        {login}
      </div> 
      <div>
        <span className="message-content">{content}</span>
      </div>
    </article>
  );
};

export default Message;
