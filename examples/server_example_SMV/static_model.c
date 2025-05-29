/*
 * static_model.c
 *
 * automatically generated from ICDFiles/simpleIO_smv.icd
 */
#include "static_model.h"

static void initializeValues();



LogicalDevice iedModel_GenericIO = {
  LogicalDeviceModelType,
  "GenericIO",
  (ModelNode*) &iedModel,
  NULL,
  (ModelNode*) &iedModel_GenericIO_666LLN051,
  NULL
};

LogicalNode iedModel_GenericIO_666LLN051 = {
  LogicalNodeModelType,
  "666LLN051",
  (ModelNode*) &iedModel_GenericIO,
  NULL,
  (ModelNode*) &iedModel_GenericIO_666LLN051_Mod
};

DataObject iedModel_GenericIO_666LLN051_Mod = {
  DataObjectModelType,
  "Mod",
  (ModelNode*) &iedModel_GenericIO_666LLN051,
  (ModelNode*) &iedModel_GenericIO_666LLN051_Beh,
  (ModelNode*) &iedModel_GenericIO_666LLN051_Mod_stVal,
  0,
  -1
};
DataAttribute iedModel_GenericIO_666LLN051_Mod_stVal = {
  DataAttributeModelType,
  "stVal",
  (ModelNode*) &iedModel_GenericIO_666LLN051_Mod,
  (ModelNode*) &iedModel_GenericIO_666LLN051_Mod_q,
  NULL,
  0,
  -1,
  IEC61850_FC_ST,
  IEC61850_ENUMERATED,
  0 + TRG_OPT_DATA_CHANGED + TRG_OPT_DATA_UPDATE + TRG_OPT_QUALITY_CHANGED,
  NULL,
  0
};
DataAttribute iedModel_GenericIO_666LLN051_Mod_q = {
  DataAttributeModelType,
  "q",
  (ModelNode*) &iedModel_GenericIO_666LLN051_Mod,
  (ModelNode*) &iedModel_GenericIO_666LLN051_Mod_t,
  NULL,
  0,
  -1,
  IEC61850_FC_ST,
  IEC61850_QUALITY,
  0,
  NULL,
  0
};
DataAttribute iedModel_GenericIO_666LLN051_Mod_t = {
  DataAttributeModelType,
  "t",
  (ModelNode*) &iedModel_GenericIO_666LLN051_Mod,
  (ModelNode*) &iedModel_GenericIO_666LLN051_Mod_ctlModel,
  NULL,
  0,
  -1,
  IEC61850_FC_ST,
  IEC61850_TIMESTAMP,
  0,
  NULL,
  0
};
DataAttribute iedModel_GenericIO_666LLN051_Mod_ctlModel = {
  DataAttributeModelType,
  "ctlModel",
  (ModelNode*) &iedModel_GenericIO_666LLN051_Mod,
  NULL,
  NULL,
  0,
  -1,
  IEC61850_FC_CF,
  IEC61850_ENUMERATED,
  0,
  NULL,
  0
};
DataObject iedModel_GenericIO_666LLN051_Beh = {
  DataObjectModelType,
  "Beh",
  (ModelNode*) &iedModel_GenericIO_666LLN051,
  (ModelNode*) &iedModel_GenericIO_666LLN051_Health,
  (ModelNode*) &iedModel_GenericIO_666LLN051_Beh_stVal,
  0,
  -1
};
DataAttribute iedModel_GenericIO_666LLN051_Beh_stVal = {
  DataAttributeModelType,
  "stVal",
  (ModelNode*) &iedModel_GenericIO_666LLN051_Beh,
  (ModelNode*) &iedModel_GenericIO_666LLN051_Beh_q,
  NULL,
  0,
  -1,
  IEC61850_FC_ST,
  IEC61850_ENUMERATED,
  0 + TRG_OPT_DATA_CHANGED + TRG_OPT_DATA_UPDATE + TRG_OPT_QUALITY_CHANGED,
  NULL,
  0
};
DataAttribute iedModel_GenericIO_666LLN051_Beh_q = {
  DataAttributeModelType,
  "q",
  (ModelNode*) &iedModel_GenericIO_666LLN051_Beh,
  (ModelNode*) &iedModel_GenericIO_666LLN051_Beh_t,
  NULL,
  0,
  -1,
  IEC61850_FC_ST,
  IEC61850_QUALITY,
  0,
  NULL,
  0
};
DataAttribute iedModel_GenericIO_666LLN051_Beh_t = {
  DataAttributeModelType,
  "t",
  (ModelNode*) &iedModel_GenericIO_666LLN051_Beh,
  NULL,
  NULL,
  0,
  -1,
  IEC61850_FC_ST,
  IEC61850_TIMESTAMP,
  0,
  NULL,
  0
};
DataObject iedModel_GenericIO_666LLN051_Health = {
  DataObjectModelType,
  "Health",
  (ModelNode*) &iedModel_GenericIO_666LLN051,
  (ModelNode*) &iedModel_GenericIO_666LLN051_NamPlt,
  (ModelNode*) &iedModel_GenericIO_666LLN051_Health_stVal,
  0,
  -1
};
DataAttribute iedModel_GenericIO_666LLN051_Health_stVal = {
  DataAttributeModelType,
  "stVal",
  (ModelNode*) &iedModel_GenericIO_666LLN051_Health,
  (ModelNode*) &iedModel_GenericIO_666LLN051_Health_q,
  NULL,
  0,
  -1,
  IEC61850_FC_ST,
  IEC61850_ENUMERATED,
  0 + TRG_OPT_DATA_CHANGED + TRG_OPT_DATA_UPDATE + TRG_OPT_QUALITY_CHANGED,
  NULL,
  0
};
DataAttribute iedModel_GenericIO_666LLN051_Health_q = {
  DataAttributeModelType,
  "q",
  (ModelNode*) &iedModel_GenericIO_666LLN051_Health,
  (ModelNode*) &iedModel_GenericIO_666LLN051_Health_t,
  NULL,
  0,
  -1,
  IEC61850_FC_ST,
  IEC61850_QUALITY,
  0,
  NULL,
  0
};
DataAttribute iedModel_GenericIO_666LLN051_Health_t = {
  DataAttributeModelType,
  "t",
  (ModelNode*) &iedModel_GenericIO_666LLN051_Health,
  NULL,
  NULL,
  0,
  -1,
  IEC61850_FC_ST,
  IEC61850_TIMESTAMP,
  0,
  NULL,
  0
};
DataObject iedModel_GenericIO_666LLN051_NamPlt = {
  DataObjectModelType,
  "NamPlt",
  (ModelNode*) &iedModel_GenericIO_666LLN051,
  NULL,
  (ModelNode*) &iedModel_GenericIO_666LLN051_NamPlt_vendor,
  0,
  -1
};
DataAttribute iedModel_GenericIO_666LLN051_NamPlt_vendor = {
  DataAttributeModelType,
  "vendor",
  (ModelNode*) &iedModel_GenericIO_666LLN051_NamPlt,
  (ModelNode*) &iedModel_GenericIO_666LLN051_NamPlt_swRev,
  NULL,
  0,
  -1,
  IEC61850_FC_DC,
  IEC61850_VISIBLE_STRING_255,
  0,
  NULL,
  0
};
DataAttribute iedModel_GenericIO_666LLN051_NamPlt_swRev = {
  DataAttributeModelType,
  "swRev",
  (ModelNode*) &iedModel_GenericIO_666LLN051_NamPlt,
  (ModelNode*) &iedModel_GenericIO_666LLN051_NamPlt_d,
  NULL,
  0,
  -1,
  IEC61850_FC_DC,
  IEC61850_VISIBLE_STRING_255,
  0,
  NULL,
  0
};
DataAttribute iedModel_GenericIO_666LLN051_NamPlt_d = {
  DataAttributeModelType,
  "d",
  (ModelNode*) &iedModel_GenericIO_666LLN051_NamPlt,
  (ModelNode*) &iedModel_GenericIO_666LLN051_NamPlt_configRev,
  NULL,
  0,
  -1,
  IEC61850_FC_DC,
  IEC61850_VISIBLE_STRING_255,
  0,
  NULL,
  0
};
DataAttribute iedModel_GenericIO_666LLN051_NamPlt_configRev = {
  DataAttributeModelType,
  "configRev",
  (ModelNode*) &iedModel_GenericIO_666LLN051_NamPlt,
  (ModelNode*) &iedModel_GenericIO_666LLN051_NamPlt_ldNs,
  NULL,
  0,
  -1,
  IEC61850_FC_DC,
  IEC61850_VISIBLE_STRING_255,
  0,
  NULL,
  0
};
DataAttribute iedModel_GenericIO_666LLN051_NamPlt_ldNs = {
  DataAttributeModelType,
  "ldNs",
  (ModelNode*) &iedModel_GenericIO_666LLN051_NamPlt,
  NULL,
  NULL,
  0,
  -1,
  IEC61850_FC_EX,
  IEC61850_VISIBLE_STRING_255,
  0,
  NULL,
  0
};



extern SettingGroupControlBlock iedModel_GenericIO_666LLN051_sgcb;

SettingGroupControlBlock iedModel_GenericIO_666LLN051_sgcb = {
  &iedModel_GenericIO_666LLN051,
  98,
  77,
  0,
  false,
  0,
  0,
  NULL,
};

extern SVControlBlock iedModel_GenericIO_666LLN051_smv0;
extern SVControlBlock iedModel_GenericIO_666LLN051_smv1;


static PhyComAddress iedModel_GenericIO_666LLN051_smv0_address = {
  4,
  123,
  4000,
  {0x1, 0xc, 0xcd, 0x4, 0x0, 0x1}
};

SVControlBlock iedModel_GenericIO_666LLN051_smv0 = {
  &iedModel_GenericIO_666LLN051,
  "NewSMVControl",
  "666655dd",
  "Events2",
  23,
  1,
  555,
  5,
  &iedModel_GenericIO_666LLN051_smv0_address,
  true,
  98,
  &iedModel_GenericIO_666LLN051_smv1
};

static PhyComAddress iedModel_GenericIO_666LLN051_smv1_address = {
  4,
  123,
  4000,
  {0x1, 0xc, 0xcd, 0x4, 0x0, 0x1}
};

SVControlBlock iedModel_GenericIO_666LLN051_smv1 = {
  &iedModel_GenericIO_666LLN051,
  "NewSMVControl1",
  NULL,
  "Events2",
  0,
  NULL,
  -1,
  -1,
  &iedModel_GenericIO_666LLN051_smv1_address,
  false,
  -1,
  NULL
};



IedModel iedModel = {
  "simpleIO",
  &iedModel_GenericIO,
  NULL,
  NULL,
  NULL,
  &iedModel_GenericIO_666LLN051_smv0,
  &iedModel_GenericIO_666LLN051_sgcb,
  NULL,
  NULL,
  initializeValues
};

static void
initializeValues()
{

iedModel_GenericIO_666LLN051_Mod_stVal.mmsValue = MmsValue_newIntegerFromInt32(1);

iedModel_GenericIO_666LLN051_Mod_ctlModel.mmsValue = MmsValue_newIntegerFromInt32(0);

iedModel_GenericIO_666LLN051_Beh_stVal.mmsValue = MmsValue_newIntegerFromInt32(1);

iedModel_GenericIO_666LLN051_Health_stVal.mmsValue = MmsValue_newIntegerFromInt32(1);

iedModel_GenericIO_666LLN051_NamPlt_vendor.mmsValue = MmsValue_newVisibleString("MZ Automation");

iedModel_GenericIO_666LLN051_NamPlt_swRev.mmsValue = MmsValue_newVisibleString("1.3.0");

iedModel_GenericIO_666LLN051_NamPlt_d.mmsValue = MmsValue_newVisibleString("libiec61850 server example");
}
