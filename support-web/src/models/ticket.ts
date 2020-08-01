import User from './user';
import Comment from './comment';

class Ticket {
  id = -1;

  code?: string;

  description?: string;

  type?: string;

  priority?: string;

  openingDate?: string;

  closingDate?: string;

  status?: string;

  owner?: User;

  comments?: Array<Comment>;
}

export default Ticket;
