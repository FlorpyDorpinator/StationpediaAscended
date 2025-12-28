# StationpediaPlus - Architecture Plan

## Project Vision
Replace the outdated Stationeers wiki with a community-driven, in-game integrated documentation system that pulls from a public Git repository and allows player contributions with human review.

---

## System Components

### 1. Data Repository (GitHub)
```
StationpediaPlus-Data/
├── devices/                    # Device documentation (JSON)
├── mechanics/                  # Game mechanics explanations
├── guides/                     # Player-written guides
├── changelogs/                 # Beta changelog tracking
├── meta/
│   ├── review-status.json      # Human review tracking
│   ├── pending-edits/          # Submitted but not approved
│   └── contributors.json       # Contributor credits
└── schema/                     # JSON schemas for validation
```

**Why GitHub?**
- Free hosting
- Version control built-in
- Pull request system for reviews
- Raw file access for mod to fetch: `https://raw.githubusercontent.com/[org]/StationpediaPlus-Data/main/devices/aimee.json`
- Community can fork and contribute
- Actions can validate submissions automatically

### 2. In-Game Mod (BepInEx/Unity)
```
StationpediaPlus/
├── Plugin.cs                   # Main BepInEx entry
├── DataFetcher.cs              # Pulls JSON from GitHub
├── StationpediaPatch.cs        # Harmony patches to existing UI
├── EditMode/
│   ├── EditModeUI.cs           # Edit button and form
│   ├── SubmissionManager.cs    # Package and send edits
│   └── LocalDraftStorage.cs    # Save drafts locally
├── UI/
│   ├── EnhancedPageRenderer.cs # Render our JSON as pages
│   ├── ReviewBadge.cs          # Green checkmark display
│   └── SearchEnhancements.cs   # Better search
└── Config/
    └── settings.json           # User preferences, cache settings
```

### 3. Admin Review Tool (Out-of-Game)
Options (in order of simplicity):
1. **GitHub Web Interface** - Use PRs directly, no custom tool needed initially
2. **Simple Web App** - React/Vue dashboard that uses GitHub API
3. **Desktop App** - Electron or .NET MAUI for richer experience

**Recommended: Start with GitHub PRs, build custom tool later**

---

## Data Flow

### Reading Data (In-Game)
```
┌─────────────┐     HTTPS GET      ┌─────────────────┐
│  Mod        │ ─────────────────► │  GitHub Raw     │
│  (in-game)  │ ◄───────────────── │  (JSON files)   │
└─────────────┘     JSON response  └─────────────────┘
       │
       ▼
┌─────────────┐
│  Local      │  (cache for offline play)
│  Cache      │
└─────────────┘
```

### Submitting Edits (Player Contribution)
```
┌─────────────┐     1. Edit in-game     ┌─────────────┐
│  Player     │ ──────────────────────► │  Mod UI     │
└─────────────┘                         └─────────────┘
                                              │
                    2. Submit (creates PR or webhook)
                                              ▼
                                        ┌─────────────────┐
                                        │  GitHub         │
                                        │  (PR or Issue)  │
                                        └─────────────────┘
                                              │
                    3. Admin reviews via GitHub or custom tool
                                              ▼
                                        ┌─────────────────┐
                                        │  Merged to      │
                                        │  main branch    │
                                        └─────────────────┘
                                              │
                    4. Next mod fetch gets updated data
                                              ▼
                                        ┌─────────────────┐
                                        │  All players    │
                                        │  see update     │
                                        └─────────────────┘
```

---

## Contribution Methods

### Option A: GitHub Account Required
- Player authenticates with GitHub OAuth
- Mod creates PR directly
- **Pros:** Real attribution, uses existing PR system
- **Cons:** Barrier to entry, OAuth complexity

### Option B: Anonymous via Webhook
- Mod sends edit to a webhook (Discord, custom server, or GitHub Issue)
- Admin manually creates PR from submission
- **Pros:** Zero friction, no accounts needed
- **Cons:** More admin work, potential spam

### Option C: Hybrid
- Anonymous submissions go to a "pending" queue (GitHub Issues with label)
- GitHub users can create PRs directly
- **Recommended approach**

---

## Review Status System

### Status Badges
```json
{
  "pageId": "devices/aimee",
  "status": "reviewed",           // "draft" | "pending" | "reviewed"
  "reviewedBy": "username",
  "reviewedAt": "2025-12-27T10:00:00Z",
  "generatedBy": "claude-opus-4.5",
  "generatedAt": "2025-12-26T15:30:00Z",
  "version": "1.0.0",
  "gameVersion": "Respawn Update"
}
```

### Visual Indicators (In-Game)
- ✅ Green checkmark = Human reviewed
- 🤖 Robot icon = AI-generated, awaiting review
- 📝 Pencil icon = Has pending edits
- ⚠️ Warning = Flagged for update (changelog detected change)

---

## Technical Feasibility Answers

### Can the mod pull from GitHub?
**Yes.** Unity's `UnityWebRequest` can fetch any HTTPS URL. Example:
```csharp
IEnumerator FetchDeviceData(string deviceId) {
    string url = $"https://raw.githubusercontent.com/org/repo/main/devices/{deviceId}.json";
    using (UnityWebRequest www = UnityWebRequest.Get(url)) {
        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.Success) {
            DeviceData data = JsonUtility.FromJson<DeviceData>(www.downloadHandler.text);
        }
    }
}
```

### Can edits be sent to Git from in-game?
**Yes, with caveats:**
- Direct GitHub API requires OAuth (complex)
- Webhook to Discord/custom server is simpler
- Can create GitHub Issues via API without full OAuth
- Could use a simple relay server (Cloudflare Workers, free tier)

### Can we modify the existing Stationpedia UI?
**Yes.** BepInEx + Harmony allows patching any Unity/C# game. The Stationpedia is just a UI panel we can inject into.

---

## Phase 1 MVP Scope

### What we build first:
1. ✅ Device JSON files (all 106 devices)
2. ✅ Human review tracking (review-status.json)
3. ✅ Basic mod that reads from GitHub and displays enhanced pages
4. ⏸️ Edit mode (phase 2)
5. ⏸️ Admin tool (phase 2, use GitHub PRs initially)

### Minimum Viable Product:
- Mod loads device data from GitHub
- Displays in enhanced Stationpedia UI
- Shows review status badges
- Caches locally for offline
- No edit submission yet (manual contributions via GitHub)

---

## Next Steps

1. Create the data repository structure
2. Define JSON schema for devices
3. Build multi-agent coordination system for content creation
4. Generate all device pages
5. Set up human review workflow
6. Build basic mod (read-only first)

---

## Open Questions

1. **Hosting:** Use personal GitHub or create an organization?
2. **Mod Distribution:** Thunderstore? GitHub Releases? Both?
3. **Stationpedia Bugs:** What visual bugs need fixing? Need list.
4. **Beta Changelogs:** Discord webhook? Manual paste? RSS?
5. **Community Input:** When to announce and gather feedback?
