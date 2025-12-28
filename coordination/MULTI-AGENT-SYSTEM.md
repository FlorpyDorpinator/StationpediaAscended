# Multi-Agent Coordination System

## Purpose
This document enables multiple Claude sessions to work in parallel on StationpediaPlus content creation without duplicating work or creating conflicts.

---

## How It Works

1. **Master Device List** (`device-tracking.json`) tracks all devices and their status
2. Each agent session **claims** a batch before starting
3. Agents update status as they complete work
4. Conductor (main session) coordinates and reviews

---

## Agent Roles

### Conductor Agent (You/Primary Session)
- Maintains master tracking file
- Assigns batches to worker agents
- Reviews completed work
- Resolves conflicts
- Updates review status

### Worker Agents (Parallel Sessions)
- Receive batch assignment via instruction file
- Create device documentation
- Report completion
- Do NOT modify tracking file (conductor does this)

---

## Workflow

### Step 1: Conductor Assigns Batch
Conductor creates an instruction file:
```
agent-instructions/batch-001.md
```

### Step 2: Worker Reads Instructions
Worker agent is given the instruction file which contains:
- Assigned device list
- Template to follow
- Output location
- Completion checklist

### Step 3: Worker Creates Content
Worker creates files in:
```
data/devices/[device-name].json
wiki/devices/[device-name].md
```

### Step 4: Worker Reports Completion
Worker creates completion report:
```
agent-reports/batch-001-complete.md
```

### Step 5: Conductor Updates Tracking
Conductor reads report and updates `device-tracking.json`

---

## File Locations

```
StationpediaPlus/
├── coordination/
│   ├── device-tracking.json      # Master list (conductor only edits)
│   ├── agent-instructions/       # Task assignments
│   │   ├── batch-001.md
│   │   ├── batch-002.md
│   │   └── ...
│   ├── agent-reports/            # Completion reports
│   │   ├── batch-001-complete.md
│   │   └── ...
│   └── templates/
│       ├── device-template.md    # Markdown template
│       ├── device-schema.json    # JSON schema
│       └── agent-prompt.md       # Instructions for agents
├── data/
│   └── devices/                  # JSON output
└── wiki/
    └── devices/                  # Markdown output
```

---

## Device Status Values

| Status | Meaning |
|--------|---------|
| `unassigned` | Not yet claimed by any agent |
| `assigned` | Claimed by agent, work in progress |
| `draft` | Content created, awaiting conductor review |
| `reviewed` | Conductor verified, awaiting human review |
| `approved` | Human reviewed and approved |
| `flagged` | Needs update (game change detected) |

---

## Conflict Prevention Rules

1. **Agents MUST check assignment before starting** - Read your batch file
2. **Agents MUST NOT work on devices not in their batch**
3. **Only Conductor updates device-tracking.json**
4. **Agents create files, never modify existing ones**
5. **If conflict detected, STOP and report to conductor**

---

## Batch Size Guidelines

- **Standard batch:** 10-15 devices
- **Complex devices (rockets, etc.):** 5-8 devices
- **Simple devices (sensors, logic):** 15-20 devices

---

## Communication Protocol

### Agent → Conductor
Via completion report file containing:
- Devices completed (list)
- Devices skipped (if any, with reason)
- Issues encountered
- Time taken (approximate)

### Conductor → Agent
Via instruction file containing:
- Batch number
- Device list with source file paths
- Any special instructions
- Template reference

---

## Starting a Worker Session

Give new Claude session this prompt:

```
You are a Worker Agent for the StationpediaPlus project. Your role is to create device documentation.

Read your assignment at:
StationpediaPlus/coordination/agent-instructions/batch-XXX.md

Follow the template at:
StationpediaPlus/coordination/templates/device-template.md

Create files at:
- StationpediaPlus/data/devices/[name].json
- StationpediaPlus/wiki/devices/[name].md

When done, create completion report at:
StationpediaPlus/coordination/agent-reports/batch-XXX-complete.md

Do NOT modify device-tracking.json - only the conductor does that.
Do NOT work on devices outside your assigned batch.
```

---

## Error Handling

### If source file not found:
- Skip device
- Report in completion file
- Conductor will reassign

### If device already has documentation:
- Skip device
- Report potential duplicate
- Conductor will investigate

### If unclear about implementation:
- Create with best effort
- Add "NEEDS_REVIEW" tag in notes
- Explain uncertainty in completion report
