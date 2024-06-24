export interface TaskDto {
  id: number;
  title: string;
  description: string;
  statusId: number;
  statusName: string;
  dueDate: Date;
  createdDate: Date;
  updatedDate: Date;
  priorityId: number;
  priorityName: string;
  userId: number;
  projectId?: number;
}
