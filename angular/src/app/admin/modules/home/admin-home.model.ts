export interface CreateInformation {
  title: string;
  content: string;
  icon: string;
  keyName: string;
  moduleId: string;
  language: number;
}
export interface Information {
  id: string;
  creationTime: string;
  creatorId: string;
  lastModificationTime: string;
  lastModifierId: string;
  title: string;
  content: string;
  icon: string;
  keyName: string;
  moduleId: string;
  language: number;
}

export interface UpdateInformation {
  informationId: string;
  title: string;
  content: string;
  icon: string;
  keyName: string;
}

export interface Module {
  moduleName: string;
  keyName: string;
  parentId: any;
  language: number;
  lastModificationTime: any;
  lastModifierId: any;
  creationTime: string;
  creatorId: any;
  id: string;
}